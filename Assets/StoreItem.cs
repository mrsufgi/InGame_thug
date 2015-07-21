using UnityEngine;
using System.Collections;
using Soomla.Store;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour {

    private VirtualCurrencyPack m_CurrencyPack;
    private Button m_Button;

    public VirtualCurrencyPack CurrencyPack
    {
        get { return m_CurrencyPack; }
        set { m_CurrencyPack = value;  }
    }

    public int m_Amount;
    public string m_Price;

    void Start () {

        m_Button = this.GetComponent<Button>();
        m_Button.onClick.AddListener(() => BuyPack());


    }

    public void BuyPack()
    {
        m_CurrencyPack.Buy(string.Format("YOU BOUGHT: {0} COINS. PAYED: {1}", m_Amount + "", m_Price));

    }




    // Update is called once per frame
}
