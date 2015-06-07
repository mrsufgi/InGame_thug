using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla.Highway;
using Soomla;
using Soomla.Store;
using Soomla.Profile;

public class MainGame : MonoBehaviour
{
	
	private static LevelUpEventHandler handler = new LevelUpEventHandler();
	// Use this for initialization
	void Start()
	{
		// Initialize Event Handler
		
		// cleaR PLAYERPREF!!!!!!!!!!!!!!
		//     PlayerPrefs.DeleteAll();

		//  SoomlaHighway.Initialize();
		//  IStoreAssets store = new StoreAssets();
		//  store.GetVersion();
		SoomlaHighway.Initialize();
		StoreAssets store = new StoreAssets();
		print(store);
		store.GetVersion();
		SoomlaStore.Initialize(store);
		// Initialize LevelUp
		// World mainWorld = new InitialWorld().createMainWorld();
		
		
		
		SoomlaLevelUp.Initialize(new InitialWorld().createMainWorld());
		
		
		int firstRun = PlayerPrefs.GetInt("firstRun");
		print(firstRun);
		if (firstRun == 0)
		{
			StoreAssets.COIN_CURRENCY.Give(10000);
			PlayerPrefs.SetInt("firstRun", 1);
		}
		else
		{
			
			// not first run
		}
	}
	
	
	void Awake()
	{
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}