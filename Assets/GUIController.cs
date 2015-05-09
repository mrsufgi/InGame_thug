using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla;
using UnityEngine.UI;
using Soomla.Store;

public class GUIController : MonoBehaviour {

    public Text gasCoinText;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        // update gasCoins text
        gasCoinText.text = StoreInventory.GetItemBalance("coin_currency_ID") + " " ;


	}
}
