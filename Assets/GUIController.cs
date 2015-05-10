using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

    public Text gasCoinText;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        // update gasCoins text
        gasCoinText.text = StoreAssets.COIN_CURRENCY.GetBalance() + "";


	}
}
