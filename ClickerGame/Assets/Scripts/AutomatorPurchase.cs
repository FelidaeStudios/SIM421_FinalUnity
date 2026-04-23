using UnityEngine;

public class AutomatorPurchase : MonoBehaviour
{
    public int cost;

    public void TenSecondAutomatePurchase()
    {
        if (GameManager.currentScore >= cost)
        {
            GameManager.currentScore -= cost;
            GameManager.tenSecondAutomateAmount += 1;
        }
    }

    public void FiveSecondAutomatePurchase()
    {
        if (GameManager.currentScore >= cost)
        {
            GameManager.currentScore -= cost;
            GameManager.fiveSecondAutomateAmount += 1;
        }
    }
}
