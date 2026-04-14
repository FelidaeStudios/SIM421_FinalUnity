using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Events;

public class RegisterController : MonoBehaviour
{
    //[Header("API")]
    private string apiUrl = "http://127.0.0.1:8000/register";

    [Header("UI")]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField passwordConfirmInput;
    public TMP_InputField emailInput;

    [Header("Menus")]
    public GameObject gameMenu;
    public GameObject loginMenu; //Already registered, misclicked on register button -> "Already registered? Log in!"
    public GameObject registerMenu; //Register menu
    public GameObject homeMenu; //Cancelling registration for whatever reason, not logging in

    void Start()
    {
        StartCoroutine(CallApi());
    }

    void Update()
    {
        
    }

    /*public void OnRegister() //Mycelium registration function
    {
        string username = "TestUser";
        string password = "password1";

        RegisterPlayFabUserRequest registerRequest = new RegisterPlayFabUserRequest
        {
            Username = usernameInput.text,
            DisplayName = usernameInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(registerRequest,
            result =>
            {
                SetDisplayText(result.PlayFabId, Color.green);
            },
            error =>
            {
                SetDisplayText(error.ErrorMessage, Color.red);
            }
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

    public void OnRegisterButton()
    {
        //Call API, register user, send to login.
    }

    //Send to login page.
    public void OnLoginButton()
    {
        loginMenu.SetActive(true);
        loginMenu.SetActive(false);
    }

    //Send back to home page.
    public void OnHomeButton()
    {
        homeMenu.SetActive(true);
        registerMenu.SetActive(false);
    }

    //Quit game.
    public void OnQuit()
    {
        Debug.Log("Quitting game.");
        Application.Quit();
    }
}
