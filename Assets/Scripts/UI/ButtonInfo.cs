/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;

    void Update()
    {
        PriceTxt.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString() + "€";
        QuantityTxt.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString();
    }

    public void OnBuyButtonClick()
    {
        ShopManager.GetComponent<ShopManagerScript>().Buy(ItemID);
    }

    public void OnSellButtonClick()
    {
        ShopManager.GetComponent<ShopManagerScript>().Sell(ItemID);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Item" + ItemID))
        {
            QuantityTxt.text = PlayerPrefs.GetInt("Item" + ItemID).ToString();
        }
    }
}*/
