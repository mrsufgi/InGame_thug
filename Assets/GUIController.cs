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

	}

   public void PayCoins()
    {
        StoreAssets.COIN_CURRENCY.Take(50);
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(startWait);
        Application.LoadLevel(level);

    }

    public void CollectCoins()
    {
        StoreAssets.COIN_CURRENCY.Give(50);
    }

}
