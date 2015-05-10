using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla;
using Soomla.Store;

public class WorldLoader : MonoBehaviour {

    bool isOpen;
    bool isComplete;
    // static loader...
    public void World_two_Load()
    {
        SoomlaLevelUp.GetWorld("blueWorld_ID").SetCompleted(true);

        

        //if (SoomlaLevelUp.GetGate("redRecordGate_ID").Open()) {
        //    print(SoomlaLevelUp.GetGate("redRecordGate_ID").IsOpen());
        //}

        //if (SoomlaLevelUp.GetGate("redGate_ID").Open())
        //{
        //    print(SoomlaLevelUp.GetGate("redGate_ID").IsOpen());
        //}

        //if (SoomlaLevelUp.GetGate("redWorldORGate_ID").Open())
        //{
        //    print(SoomlaLevelUp.GetGate("redWorldORGate_ID").IsOpen());
        //}

        if (SoomlaLevelUp.GetWorld("redWorld_ID").Gate.Open()) {
            
            print(SoomlaLevelUp.GetWorld("main_world").GetSingleScore().Latest + "");
          //  SoomlaLevelUp.GetScore("gasCoins_ID").Inc(1500);
            StoreInventory.GiveItem(StoreAssets.COIN_CURRENCY.ID, 1000);
            print(SoomlaLevelUp.GetWorld("main_world").GetSingleScore().GetTempScore() + "");
            print("should load");
            Application.LoadLevel("world");


        }
        else
        {
            print("fu");
        }
    }

    void Start()
    {
        Application.LoadLevel("world");
    }

    public void World_one_Load()
    {

        Application.LoadLevel("world");

    } 

}
