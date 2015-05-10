using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla;
using UnityEngine.UI;

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

        // update gasCoins text
        gasCoinText.text = "Gas Coins: " +  StoreAssets.COIN_CURRENCY.GetBalance();
		if (StoreAssets.COIN_CURRENCY.GetBalance() >= 50)
		{
			pay.interactable = true;
		}

	}

   public void PayCoins()
    {
//		if (StoreAssets.COIN_CURRENCY.GetBalance () >= 50) {
//			StoreAssets.COIN_CURRENCY.Take (50);
//		}
        StartCoroutine(wait());
		Debug.Log ("here");
		Application.LoadLevel(level);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(startWait);
    }

    public void CollectCoins()
    {
        StoreAssets.COIN_CURRENCY.Give(50);
		StoreAssets.COIN_CURRENCY.Save ();
    }

}
