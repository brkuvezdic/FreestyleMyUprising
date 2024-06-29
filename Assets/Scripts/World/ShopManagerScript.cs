/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManagerScript : MonoBehaviour
{


//RESET SPREMLJENIH STATOVA I COINA
    // public void ResetPlayerPrefs()
    // {
    //     PlayerPrefs.DeleteAll();
    //     PlayerPrefs.Save();
    //     Debug.Log("All PlayerPrefs data has been reset.");
    // }

    public int[,] shopItems = new int[5, 5];
    public float coins;
    public Text CoinsTXT;
    public bool purchaseLocked = false;

    private CoinManager coinManager;

    void Start()
    {
        coinManager = CoinManager.instance;

        if (coinManager != null)
        {
            coins = coinManager.coinCount;
            UpdateCoinsText();
            InitializeShopItems();
            LoadPurchases(); // Load purchases on start
        }
        else
        {
            Debug.LogWarning("CoinManager instance not found!");
        }

        //RESET SPREMLJENIH STATOVA I COINA
       // ResetPlayerPrefs();
    }

    void InitializeShopItems()
    {
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        shopItems[2, 1] = 1;
        shopItems[2, 2] = 2;
        shopItems[2, 3] = 3;
        shopItems[2, 4] = 10;

        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
    }

    void UpdateCoinsText()
    {
        CoinsTXT.text = "Coins: " + coins.ToString();
    }

public void Buy(int itemID)
{
    if (!purchaseLocked)
    {
        if (coins >= shopItems[2, itemID])
        {
            coins -= shopItems[2, itemID];
            shopItems[3, itemID]++;
            UpdateCoinsText();
            UpdateItemQuantityText(itemID);

            // If itemID is 1, increase current and max health by 10
            if (itemID == 1)
            {
                PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.IncreaseHealthByTen();
                }
                else
                {
                    Debug.LogError("PlayerStats component not found on the player GameObject!");
                }
            }

            SavePurchases(); // Save purchases after buying
        }
        else
        {
            Debug.Log("Not enough coins to purchase item.");
        }
        coinManager.UpdateCoinCount((int)coins);
    }
    else
    {
        Debug.Log("Purchase is locked. Cannot buy more items.");
    }
}



   public void Sell(int itemID)
{
    if (shopItems[3, itemID] > 0)
    {
        if (itemID == 1) // Check if the sold item is the first one
        {
            PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            // Revert the changes to current and max health
            playerStats.maxHealth -= 10;
            playerStats.currentHealth = Mathf.Min(playerStats.currentHealth, playerStats.maxHealth); // Ensure current health doesn't exceed max health
        }

        shopItems[3, itemID]--;
        coins += shopItems[2, itemID];
        UpdateCoinsText();
        UpdateItemQuantityText(itemID);
        coinManager.UpdateCoinCount((int)coins);
        SavePurchases(); // Save purchases after selling
    }
    else
    {
        Debug.Log("No items to sell.");
    }
}


    void UpdateItemQuantityText(int itemID)
    {
        GameObject itemObject = GameObject.Find("Item" + itemID);
        if (itemObject != null)
        {
            ButtonInfo buttonInfo = itemObject.GetComponent<ButtonInfo>();
            if (buttonInfo != null)
            {
                buttonInfo.QuantityTxt.text = shopItems[3, itemID].ToString();
            }
            else
            {
                Debug.LogWarning("ButtonInfo component not found on item object.");
            }
        }
        else
        {
            Debug.LogWarning("Item object not found.");
        }
    }

    public void LogPurchase()
    {
        for (int i = 1; i < shopItems.GetLength(1); i++)
        {
            Debug.Log("Item ID: " + i + ", Quantity: " + shopItems[3, i]);
        }
        Debug.Log("Remaining coins: " + coins);
    }

    public void ReturnToHUB()
    {
        SceneManager.LoadScene(4);
    }

    // Save purchases to PlayerPrefs
    void SavePurchases()
    {
        for (int i = 1; i < shopItems.GetLength(1); i++)
        {
            PlayerPrefs.SetInt("Item" + i, shopItems[3, i]);
        }
        PlayerPrefs.Save();
    }

    // Load purchases from PlayerPrefs
    void LoadPurchases()
    {
        for (int i = 1; i < shopItems.GetLength(1); i++)
        {
            if (PlayerPrefs.HasKey("Item" + i))
            {
                shopItems[3, i] = PlayerPrefs.GetInt("Item" + i);
            }
        }
    }
}*/