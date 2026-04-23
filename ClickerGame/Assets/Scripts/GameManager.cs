using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public static int totalScore;
    public static int currentScore;

    //[Header("Multipliers")]
    public static int doubleMultAmount = 1;
    public static int tripleMultAmount = 1;

    //[Header("Automators")]
    public static int tenSecondAutomateAmount = 0;
    public static int fiveSecondAutomateAmount = 0;

    [Header("UI")]
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI totalScoreText;

    void Start()
    {
        totalScore = 0;
        currentScore = 0;
    }

    void Update()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        currentScoreText.text = currentScore.ToString();
        totalScoreText.text = totalScore.ToString();
    }
}
