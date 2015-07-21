using UnityEngine;
using System.Collections;
using Soomla.Store;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class ShopHandler : MonoBehaviour
{

    private List<GameObject> m_storeItems;
    public GameObject StoreItem;
    private Button m_Button;
    // Use this for initialization
    void Start()
    {

        m_storeItems = new List<GameObject>();

        foreach (VirtualCurrencyPack p in MainGame.Store.GetCurrencyPacks())
        {
//          
            // NEW ITEM - ADD TO ITEM ARRAY
            GameObject LevelSelectObject = Instantiate(StoreItem) as GameObject;
            m_storeItems.Add(StoreItem);

            LevelSelectObject.name = p.Name;
            LevelSelectObject.transform.parent = gameObject.transform;
            LevelSelectObject.transform.localScale = new Vector3(1, 1, 1);

            // Inject data:
            // AMOUNT
            LevelSelectObject.transform.FindChild("GasCoinsPanel/txt_GasPoints").GetComponent<Text>().text = p.CurrencyAmount + "";

            // PRICE
            LevelSelectObject.transform.FindChild("PriceTag/Price_txt").GetComponent<Text>().text = p.PurchaseType.GetPrice() + "$";
            p.PurchaseType.GetPrice();

            StoreItem currentStoreItem = LevelSelectObject.GetComponent<StoreItem>();
            currentStoreItem.m_Price = p.PurchaseType.GetPrice();
            currentStoreItem.m_Amount = p.CurrencyAmount;
            currentStoreItem.CurrencyPack = p;
        }      
    }

    private void BuyPackage(VirtualCurrencyPack m_Pack)
    {
        m_Pack.Buy(string.Format("YOU BOUGHT: {0} COINS. PAYED: {1}", m_Pack.CurrencyAmount, m_Pack.PurchaseType.GetPrice() + ""));

    }

    public static double GetNumericPrice(VirtualGood good)
    {
        return (good.PurchaseType as PurchaseWithMarket).MarketItem.Price;
    }
}