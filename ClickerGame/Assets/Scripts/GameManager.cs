using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    //public bool isPlaying;
    //public GameObject playButton;
    public static int totalScore;
    public static int currentScore;

    public static int doubleMultAmount = 1;
    public static int automateAmount = 0;

    //[UI]
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI totalScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalScore = 0;
        currentScore = 0;
        //StartCoroutine(Automate());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        currentScoreText.text = currentScore.ToString();
        totalScoreText.text = totalScore.ToString();
    }

    // IEnumerator Automate()
    // {
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(10f);
    //         AutomatePoints();
    //     }
    // }

    // public void AutomatePoints()
    // {
    //     if (automateAmount > 0)
    //     {
    //         //add one point every 10 seconds for each automate
    //         currentScore += automateAmount * 1;
    //     }
    // }
}
