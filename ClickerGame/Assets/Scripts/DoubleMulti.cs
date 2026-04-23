using UnityEngine;

public class DoubleMulti : MonoBehaviour
{
    public int cost;
    //private int multAmount;

    public void DoubleMultPurchase()
    {
        if (GameManager.currentScore >= cost)
        {
            GameManager.currentScore -= cost;

            if (GameManager.doubleMultAmount < 2)
            {
                GameManager.doubleMultAmount++;
            }
            else
            {
                GameManager.doubleMultAmount += 2;
                Debug.Log(GameManager.doubleMultAmount);
            }
        }
    }
}
