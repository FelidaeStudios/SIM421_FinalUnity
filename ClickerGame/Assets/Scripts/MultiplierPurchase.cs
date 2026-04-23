using UnityEngine;

public class MultiplierPurchase : MonoBehaviour
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

    public void TripleMultPurchase()
    {
        if (GameManager.currentScore >= cost)
        {
            GameManager.currentScore -= cost;

            if (GameManager.tripleMultAmount < 3)
            {
                GameManager.tripleMultAmount += 2;
            }
            else
            {
                GameManager.tripleMultAmount += 3;
                Debug.Log(GameManager.tripleMultAmount);
            }
        }
    }
}
