using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    //private string apiUrl = "http://127.0.0.1:8000/score";
    public static int playerId = 1;

    public bool isPlaying = false;

    public static int totalScore;
    public static int currentScore;

    //[Header("Multipliers")]
    public static int doubleMultAmount = 1;
    public static int tripleMultAmount = 1;

    //[Header("Automators")]
    public static int tenSecondAutomateAmount = 0;
    public static int fiveSecondAutomateAmount = 0;

    [Header("UI")]
    public GameObject startButton;
    public GameObject endButton;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI totalScoreText;
    public GameObject gameMenu;

    void Start()
    {
        //totalScore = 0;
        //currentScore = 0;
        // StartCoroutine(CallApi());
    }

    void Update()
    {
        UpdateScoreText();
    }

    public void StartGame()
    {
        isPlaying = true;
        totalScore = 0;
        currentScore = 0;
        startButton.SetActive(false);
        gameMenu.SetActive(true);
        endButton.SetActive(true);
    }

    public void EndGame()
    {
        isPlaying = false;
        startButton.SetActive(true);
        gameMenu.SetActive(false);
        endButton.SetActive(false);
    }

    public void UpdateScoreText()
    {
        currentScoreText.text = currentScore.ToString();
        totalScoreText.text = totalScore.ToString();
    }

    // IEnumerator CallApi(int value)
    // {
    //     using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
    //     {
    //         yield return request.SendWebRequest();

    //         if (request.result == UnityWebRequest.Result.ConnectionError || 
    //             request.result == UnityWebRequest.Result.ProtocolError)
    //         {
    //             Debug.LogError("API Error: " + request.error);
    //         }
    //         else
    //         {
    //             string jsonResponse = request.downloadHandler.text;
    //             Debug.Log("API Response: " + jsonResponse);
    //         }
    //     }
    // }
}
