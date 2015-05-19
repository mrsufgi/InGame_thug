using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla;
using UnityEngine.UI;
using Soomla.Store;

public class GUIController : MonoBehaviour {


    public Button pay;
    public Button Collect;
    public Text gasCoinText;
    public static int level = 3;//meaning level 1
    public float startWait = 3;
    // Use this for initialization
    void Start () {
	  if (StoreAssets.COIN_CURRENCY.GetBalance() < 100)
        {
            pay.interactable = false;
        }


    }
	
	// Update is called once per frame
	void Update () {
        if (gasCoinText != null)
        {
          //  gasCoinText.text = "wohoo";
            // update gasCoins text
            if (StoreInventory.GetItemBalance("coin_currency_ID") > 0)
                gasCoinText.text = "" + StoreInventory.GetItemBalance("coin_currency_ID");
            else
                gasCoinText.text = "damn";
        }   
     //   gasCoinText.text = "yay";
	}

   public void PayCoins()
    {
       
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(startWait);
        Application.LoadLevel(level);

    }

    void Awake()
    {
        DontDestroyOnLoad(this);    
    }

    public void CollectCoins()
    {
        StoreAssets.COIN_CURRENCY.Give(50);
    }

}
