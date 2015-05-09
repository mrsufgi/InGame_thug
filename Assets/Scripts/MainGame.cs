using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla.Highway;
using Soomla;
using Soomla.Store;
using Soomla.Profile;

public class MainGame : MonoBehaviour {

    private static LevelUpEventHandler handler = new LevelUpEventHandler();
    // Use this for initialization
    void Start () {
        // Initialize Event Handler

        // CLEAR PLAYERPREF!!!!!!!!!!!!!!
       PlayerPrefs.DeleteAll();

        // Initialize LevelUp
        World mainWorld = new InitialWorld().createMainWorld();
         SoomlaHighway.Initialize();
        SoomlaStore.Initialize(new StoreAssets());
        SoomlaLevelUp.Initialize(mainWorld);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
