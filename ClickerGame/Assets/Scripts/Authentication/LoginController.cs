using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Events;

public class LoginController : MonoBehaviour
{
    //[Header("API")]
    private string apiUrl = "http://127.0.0.1:8000/login";

    [Header("UI")]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;

    [Header("Menus")]
    public GameObject gameMenu;
    public GameObject loginMenu; //Login menu
    public GameObject registerMenu; //Need to register still -> "Don't have an account? Register here!"
    public GameObject homeMenu; //Cancelling login for whatever reason, not registering

    void Start()
    {
        StartCoroutine(CallApi());
    }

    void Update()
    {

    }

    /*public void OnLoginButton() //Mycelium login function
    {
        LoginWithPlayFabRequest loginRequest = new LoginWithPlayFabRequest
        {
            Username = usernameInput.text,
            Password = passwordInput.text,
        };

        loginUserName = usernameInput.text;
        PhotonNetwork.NickName = loginUserName;

        PlayFabClientAPI.LoginWithPlayFab(loginRequest,
            result =>
            {
                SetDisplayText("Logged in as: " + result.PlayFabId, Color.green);

                if (onLoggedIn != null)
                    onLoggedIn.Invoke();

                playFabId = result.PlayFabId;
                menu.SetActive(true);
            },
            error => SetDisplayText(error.ErrorMessage, Color.red)
        );
    }*/

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

    public void OnLoginButton()
    {
        //https://laravel.com/docs/13.x/sanctum
        //https://stackoverflow.com/questions/42284821/create-token-in-unity-to-send-post-request-to-laravel-controller
        //Reach out to Laravel, confirm credentials, log user in
    }

    public void OnRegisterButton()
    {
        registerMenu.SetActive(true);
        loginMenu.SetActive(false);
    }

    public void OnHomeButton()
    {
        homeMenu.SetActive(true);
        loginMenu.SetActive(false);
    }

    public void OnQuit()
    {
        Debug.Log("Quitting game.");
        Application.Quit();
    }
}
