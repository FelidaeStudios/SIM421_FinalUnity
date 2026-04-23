using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class AutomationController : MonoBehaviour
{
    private string apiUrl = "http://127.0.0.1:8000/score";

    void Start()
    {
        StartCoroutine(TenSecondAutomate());
        StartCoroutine(FiveSecondAutomate());
    }

    IEnumerator TenSecondAutomate()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            TenSecondAutomateFunc();
        }
    }

    public void TenSecondAutomateFunc()
    {
        if (GameManager.tenSecondAutomateAmount > 0)
        {
            //add one point every 10 seconds for each automate
            GameManager.currentScore += GameManager.tenSecondAutomateAmount * 1;
            GameManager.totalScore += GameManager.tenSecondAutomateAmount * 1;
            StartCoroutine(CallApi(GameManager.tenSecondAutomateAmount * 1));
        }
    }

    IEnumerator FiveSecondAutomate()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            FiveSecondAutomateFunc();
        }
    }

    public void FiveSecondAutomateFunc()
    {
        if (GameManager.fiveSecondAutomateAmount > 0)
        {
            //add one point every 5 seconds for each automate
            GameManager.currentScore += GameManager.fiveSecondAutomateAmount * 1;
            GameManager.totalScore += GameManager.fiveSecondAutomateAmount * 1;
            StartCoroutine(CallApi(GameManager.fiveSecondAutomateAmount * 1));
        }
    }

    IEnumerator CallApi(int value)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl+"?score="+GameManager.totalScore+"&currency="+GameManager.currentScore))
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
