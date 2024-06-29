/*using UnityEngine;

public class InteractableCoinChest : MonoBehaviour, PlayerController.IInteractable
{
    public int coinReward = 10; // Number of coins rewarded


    public void Interact()
    {

        if (CoinManager.instance != null)
        {
            CoinManager.instance.AddCoins(coinReward);
            Debug.Log("Gained " + coinReward + " coins!");
            Destroy(gameObject); // Destroy the chest after interaction
        }
        else
        {
            Debug.LogWarning("CoinManager instance not found!");
        }
    }
}
*/