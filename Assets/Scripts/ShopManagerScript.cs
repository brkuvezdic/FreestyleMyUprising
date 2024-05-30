using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopManagerScript : MonoBehaviour
{
       public int[,] shopItems = new int[5, 5]; // Number of items + 1
    public float coins; // Declaring coins variable at the class level
    public Text CoinsTXT;   
    public bool purchaseLocked = false; // Flag to indicate whether the purchase is locked

    private CoinManager coinManager; // Reference to the CoinManager

    void Start()
    {
        CoinsTXT.text = "Coins:" + coins.ToString();
        coinManager = CoinManager.instance; // Get reference to the CoinManager instance

        if (coinManager != null)
        {
            // Update coins variable with the current coin count from CoinManager
            coins = coinManager.coinCount;


            // Initialize shop items
            shopItems[1,1] = 1;      
            shopItems[1,2] = 2;   
            shopItems[1,3] = 3;
            shopItems[1,4] = 4;   

            shopItems[2,1] = 1;      
            shopItems[2,2] = 2;   
            shopItems[2,3] = 3;
            shopItems[2,4] = 10;   

            shopItems[3,1] = 0;      
            shopItems[3,2] = 0;   
            shopItems[3,3] = 0;
            shopItems[3,4] = 0;   
        }
        else
        {
            Debug.LogWarning("CoinManager instance not found!");
        }
    }

    void Update()
    {
        // Check for right mouse button click
        if (Input.GetMouseButtonDown(1))
        {
            // Call Sell() method
            Sell();
        }
    }
  public void LockPurchase()
    {
        purchaseLocked = true;
        Debug.Log("Purchase locked.");
        LogPurchase();
    }
    public void Buy()
    {
        if (!purchaseLocked)
        {
            GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

            if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
            {
                coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
                shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
                CoinsTXT.text = "Coins:" + coins.ToString();
                ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            }
            coinManager.UpdateCoinCount((int)coins);
        }
        else
        {
            Debug.Log("Purchase is locked. Cannot buy more items.");
        }
    }

    public void Sell()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        ButtonInfo buttonInfo = ButtonRef.GetComponent<ButtonInfo>();
        if (buttonInfo != null && shopItems[3, buttonInfo.ItemID] > 0)
        {
            shopItems[3, buttonInfo.ItemID]--; // Decrease the quantity
            coins += shopItems[2, buttonInfo.ItemID]; // Refund coins
            CoinsTXT.text = "Coins:" + coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, buttonInfo.ItemID].ToString();
        }
        coinManager.UpdateCoinCount((int)coins);
    }


    private void LogPurchase()
    {
        // Log the items bought and the remaining coins
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
}