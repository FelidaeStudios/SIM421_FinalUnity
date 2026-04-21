using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class ClickerController : MonoBehaviour
{
    public GameManager gameManager;
    private int pointInitial = 1;
    private int pointGain;

    //Network
    private string apiUrl = "http://127.0.0.1:8000/score";

    //[UI]
    public TextMeshProUGUI currentScoreText;
    
    void Start()
    {
        //Debug.Log(gameManager.totalClicks);
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        currentScoreText.text = GameManager.currentScore.ToString();

    }

    public void Click()
    {
        pointGain = pointInitial * GameManager.doubleMultAmount;
        
        GameManager.currentScore += pointGain;
        GameManager.totalScore += pointGain;
        StartCoroutine(CallApi(pointGain));
    }

    /*public void ClickWithMultiplier(int value) //Multiply by designated amount
    {
        int points;

        points = value * 1;
        GameManager.currentScore++;
        StartCoroutine(CallApi(points));

    }*/

    IEnumerator CallApi(int value)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl+"?score="+value))
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
                Debug.Log("API Response: " + jsonResponse);
            }
        }
    }
}
