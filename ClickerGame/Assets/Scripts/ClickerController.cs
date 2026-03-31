using UnityEngine;
using TMPro;

public class ClickerController : MonoBehaviour
{
    private int clickCount;
    //[UI]
    public TextMeshProUGUI clickCountText;
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

        clickCount = GameManager.totalClicks;
        clickCountText.text = clickCount.ToString();
    }

    public void Click()
    {
        Debug.Log("LMB clicked");
        clickCount++;
    }
}
