using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // Singleton instance
    public int coinCount; // Counter for coin, can be referenced anywhere
    public Text coinText; // UI text for the coin

    void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene changes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void Start()
    {
        UpdateCoinText();
    }

    void Update()
    {
        UpdateCoinText();
    }

    // Function to update the coin UI text
    void UpdateCoinText()
    {
        // Check if the coinText field is assigned
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount.ToString();
        }
    }

    // Method to set the coinText field dynamically
    public void SetCoinText(Text text)
    {
        coinText = text;
    }

    // Method to update the coin count
    public void UpdateCoinCount(int newCoinCount)
    {
        coinCount = newCoinCount;
    }
}
