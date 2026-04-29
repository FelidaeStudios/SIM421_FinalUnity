using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System;

public class Leaderboard : MonoBehaviour
{
    public GameObject leaderboardCanvas;
    public GameObject[] leaderboardEntries;

    [System.Serializable]
    public class PlayerEntry {
        public int id;
        public string playerName;
        public int score;
    }  

    [System.Serializable]
    public class PlayerList {
        public List<PlayerEntry> data;
    }

    public static Leaderboard instance;
    void Awake() { instance = this; }

    private string apiUrl = "http://127.0.0.1:8000/score";

    void Start()
    {
        //StartCoroutine(CallApi());
        StartCoroutine(LeaderboardRefresh());
    }

    IEnumerator LeaderboardRefresh()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            StartCoroutine(CallApi());
        }
    }

    IEnumerator CallApi()
    {
        string url = apiUrl + "?score=0&currency=0&user_id=0";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || 
                request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("API Error: " + request.error);
            }
            else
            {
                string jsonResponse = request.downloadHandler.text;

                PlayerEntry[] entries = JsonHelper.FromJson<PlayerEntry>(jsonResponse);
                
                for (int i = 0; i < entries.Length && i < leaderboardEntries.Length; i++)
                {
                    Transform entry = leaderboardEntries[i].transform;
                    TextMeshProUGUI userPlace = entry.Find("UserPlaceLabel/UserPlace").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI userId = entry.Find("UserIDLabel/UserID").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI userScore = entry.Find("UserScoreLabel/UserScore").GetComponent<TextMeshProUGUI>();

                    userPlace.text = (i + 1).ToString();
                    userId.text = entries[i].playerName;
                    userScore.text = entries[i].score.ToString();

                    userPlace.ForceMeshUpdate();
                    userId.ForceMeshUpdate();
                    userScore.ForceMeshUpdate();
                }
            }
        }
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            string wrapped = $"{{\"data\":{json}}}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(wrapped);
            return wrapper.data;
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] data;
        }
    }
}
