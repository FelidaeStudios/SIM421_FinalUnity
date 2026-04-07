using UnityEngine;
using TMPro;

public class ClickerController : MonoBehaviour
{
    private int currentClickCount;
    //[UI]
    public TextMeshProUGUI currentClickCountText;
    public GameManager gameManager;

    void Start()
    {
        //Debug.Log(gameManager.totalClicks);
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        //if (!gameManager.isPlaying)
            //return;

        currentClickCountText.text = currentClickCount.ToString();
    }

    public void Click()
    {
        currentClickCount++;
    }
}
