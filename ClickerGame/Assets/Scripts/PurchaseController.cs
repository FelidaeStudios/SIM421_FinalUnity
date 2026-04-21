/*using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class PurchaseController : MonoBehaviour
{
    private string apiUrl = "http://127.0.0.1:8000/";

    public GameManager gameManager;
    
    [Header("Store Options")]
    public GameObject doubleMultButton;
    //public GameObject automateButton;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    void Purchase()
    {
        //Check if player has enough points, then call API to purchase item and apply multiplier
        if (GameManager.currentScore >= cost)
        {
            GameManager.currentScore -= cost;

        }
    }

    IEnumerator CallApi()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
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
}*/
