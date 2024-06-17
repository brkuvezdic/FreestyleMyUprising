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
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        LoadCoinCount(); // Load coin count on awake
    }

    void Start()
    {
        UpdateCoinText();
    }

    public void UpdateCoinCount(int value)
    {
        coinCount = value;
        UpdateCoinText();
        SaveCoinCount(); // Save coin count whenever it's updated
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount.ToString();
        }
        else
        {
            Debug.LogWarning("Coin text UI component not assigned.");
        }
    }

    // Save coin count to PlayerPrefs
    void SaveCoinCount()
    {
        PlayerPrefs.SetInt("CoinCount", coinCount);
        PlayerPrefs.Save();
    }

    // Load coin count from PlayerPrefs
    void LoadCoinCount()
    {
        if (PlayerPrefs.HasKey("CoinCount"))
        {
            coinCount = PlayerPrefs.GetInt("CoinCount");
        }
    }

    // Example method to add coins (can be called from other scripts)
    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCoinCount(coinCount);
    }


}
