using UnityEngine;

public class Automator : MonoBehaviour
{
    public int cost;

    public void purchaseAutomator()
    {
        if (GameManager.currentScore >= cost)
        {
            GameManager.currentScore -= cost;
            GameManager.automateAmount += 1;
        }
    }
}
