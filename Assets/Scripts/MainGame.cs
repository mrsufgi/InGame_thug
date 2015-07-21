using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla.Highway;
using Soomla;
using Soomla.Store;
using Soomla.Profile;

public class MainGame : MonoBehaviour
{

    public static MainGame control;
    public bool deletePlayerPref = false;
    public bool test = true;
    public static StoreAssets Store;

    void Awake()
    {
        if (control != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            control = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
         
        if (deletePlayerPref)
        {
            PlayerPrefs.DeleteAll();
        }
        
        // Highway works only on mobile, SHUTDOWN before pushing to mobile.
        if (!test)
        {
            SoomlaHighway.Initialize();
        }
        Store = new StoreAssets();
        SoomlaStore.Initialize(Store);
        World mainWorld = new InitialWorld().createMainWorld();
        SoomlaLevelUp.Initialize(mainWorld);

        // First Run
        Reward firstRun = SoomlaLevelUp.GetReward("firstRunReward");
        if(!firstRun.Give())
        {
            print("Not first Run");
        }


    }
}
