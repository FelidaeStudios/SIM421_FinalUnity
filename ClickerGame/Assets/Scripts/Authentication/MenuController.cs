using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
//using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //[Header("API")]
    private string apiUrl = "http://127.0.0.1:8000/";

    [Header("Menus")]
    public GameObject loginMenu; //Login page
    public GameObject registerMenu; //Registration page
    public GameObject homeMenu; //Home page

    void Start()
    {
        StartCoroutine(CallApi());
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

    //Go to login menu.
    public void OnGoLoginButton()
    {
        loginMenu.SetActive(true);
        homeMenu.SetActive(false);
    }

    //Go to registration menu.
    public void OnGoRegisterButton()
    {
        registerMenu.SetActive(true);
        homeMenu.SetActive(false);
    }

    //Kill the tab
    public void OnQuit()
    {
        Debug.Log("Quitting game, coward.");
    }
}
