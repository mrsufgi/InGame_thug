using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla.Highway;
using Soomla;
//using Soomla.Store;
using Soomla.Profile;
using System.Collections.Generic;
using System.Linq;
using Soomla.Store;
using System;

public class InitialWorld
{



    //
    // Utility method for creating the game's worlds
    // and levels hierarchy
    //
    public World createMainWorld()
    {
        //   PlayerPrefs.DeleteAll();

        /** Scores **/

        Score pointScore = new Score(
              "pointScore_ID",                            // ID
              "Point Score",                              // Name
              true                                        // Higher is better
            );

        //    Score starRank = new Score(
        //        "starRank_ID",
        //        "Star Rank",
        //        true
        //);


        Score gasCoins = new VirtualItemScore(
              "gasCoins_ID",                           // ID  
              "gasCoins Score",                             // Name
              true,                                 // Higher is better
              "coin_currency_ID"
        );

        /** Rewards **/

        Reward medalReward = new BadgeReward(
          "medalReward_ID",                           // ID
          "Medal Reward"                              // Name
        );

        Reward FirstRun = new VirtualItemReward(
          "firstRunReward",                           // ID
          "First run starting gasCoins",                              // Name
          "coin_currency_ID",
          6000
        );

        FirstRun.Schedule.ActivationLimit = 1;

        //    /** Missions **/

        //    // well - everything must be parsed of course.. 
        //    Mission pointMission1 = new RecordMission(
        //      "pointMission_1_ID",                          // ID
        //      "Point Mission 1",                            // Name
        //      new List<Reward>() { medalReward },            // Rewards
        //      "blueWorld_ID_level0_score0",                              // Associated score
        //      50                                           // Desired record 
        //    );

        //    Mission pointMission2 = new RecordMission(
        //   "pointMission_2_ID",                          // ID
        //   "Point Mission 2",                            // Name
        //   new List<Reward>() { medalReward },            // Rewards
        //   "blueWorld_ID_level0_score0",                              // Associated score
        //   100                                           // Desired record 
        // );

        //    Mission pointMission3 = new RecordMission(
        //  "pointMission_ID_3_ID",                          // ID
        //  "Point Mission 3",                            // Name
        //  new List<Reward>() { medalReward },                                       // Rewards
        //  "blueWorld_ID_level0_score0",                              // Associated score
        //  300                                           // Desired record 
        //);


        /** Worlds **/
        // Initial world
        World mainWorld = new World(
          "main_world", null, null, null,
          null
        );

        World blueWorld = new World(
          "blueWorld_ID",                             // ID
          null, null, null,                           // Gate, Inner worlds, Scores
          null // Missions
        );

        World redWorld = new World(
          "redWorld_ID",                              // ID
          null, null, null,                           // Gate, Inner worlds, Scores
          null  // Missions
        );

        // starRank.StartValue = 0;
        /** Levels **/

        blueWorld.BatchAddLevelsWithTemplates(
          12,                                          // Number of levels
          null,                                       // Gate template
          new List<Score>() { pointScore },          // Score templates
         new List<Mission>() { }                                         // Mission templates
        );

        redWorld.BatchAddLevelsWithTemplates(
          12,                                          // Number of levels
          null,                                       // Gate template
          new List<Score>() { pointScore },          // Score templates
          new List<Mission>() { }                                        // Mission templates
        );


        // mission that can happen during the entire game session
        //XXXX.Schedule = Schedule.AnyTimeOnce();

        // Once users finish blue world, they can continue to red world.
        Gate redGate = new WorldCompletionGate(
          "redGate_ID",                            // Item ID
          blueWorld.ID                              // Associated world ID
        );

        Gate redRecordGate = new RecordGate(
          "redRecordGate_ID",
          gasCoins.ID,
          100.0);

        Gate redWorldORGate = new GatesListOR(
            "redWorldORGate_ID",
            new List<Gate>() { redRecordGate, redGate });





        redWorld.Gate = redWorldORGate;

        // See private function below
        AddGatesToWorld(blueWorld);
        AddGatesToWorld(redWorld);

        // add missions to world
        AddMissionsToWorld(blueWorld);
        AddMissionsToWorld(redWorld);



        /** Add Worlds to Initial World **/
        mainWorld.AddInnerWorld(blueWorld);
        mainWorld.AddInnerWorld(redWorld);

        /** Add gas points**/
        mainWorld.AddScore(gasCoins);
        return mainWorld;
    }

    private void AddMissionsToWorld(World world)
    {
        foreach (Level level in world.InnerWorldsList)
        {
            int value = 50;
            for (int i = 1; i < 4; i++)
            {
                Mission mission = recordMissionGenerator(i, level.GetSingleScore().ID, level.ID, value);
                mission.Schedule.ActivationLimit = 1000;
                level.AddMission(mission);
                value += 50;
            }

        }
    }

    private void AddGatesToWorld(World world)
    {

        // Iterate over all levels of the given world
        for (int i = 1; i < world.InnerWorldsMap.Count; i++)
        {

            Level previousLevel = (Level)world.GetInnerWorldAt(i - 1);
            Level currentLevel = (Level)world.GetInnerWorldAt(i);

            // The associated world of this Level's WorldCompletionGate is the
            // previous level.
            Gate prevLevelCompletionGate = new WorldCompletionGate(
              "prevLevelCompletionGate_" + world.ID + "_level_" + i.ToString(), // ID
              previousLevel.ID                                    // Associated World
            );

            //            Gate bGate = new BalanceGate(
            //             "bGate",                              // ID
            //             StoreInfo.Currencies[0].ID,           // Associated Item ID
            //                600                          // Desired balance
            //);

            Gate pGate = new PurchasableGate(
              "LevelLock_W1_L" + i.ToString() + "_ID",              // ID
               StoreInfo.GetItemByItemId("LevelLock_W1_L" + i.ToString() + "_ID").ID               // Associated item ID
            );

            // The gates in this Level's GatesListAND are the 2 gates declared above.
            currentLevel.Gate = new GatesListOR(
              "gate_" + world.ID + "_level_" + i.ToString(),                    // ID
              new List<Gate>() { pGate, prevLevelCompletionGate }  // List of Gates
            );
            //   currentLevel.Gate = pGate;
        }
    }

    private PurchasableGate gatesListORGenerator(int i)
    {
        PurchasableGate gate = new PurchasableGate(
              "LevelLock_W1_L" + i.ToString() + "_ID",              // ID
               StoreInfo.GetItemByItemId("LevelLock_W1_L" + i.ToString() + "_ID").ID               // Associated item ID
            );
        return gate;
    }

    // TODO add rewards
    private Mission recordMissionGenerator(int i_Index, string i_ScoreID, string i_LevelID, int i_Value)
    {
        /** Missions **/
        Reward coinReward = new VirtualItemReward(
  i_LevelID + "vReward",                            // ID
  "Coin Reward",                        // Name
  "coin_currency_ID",                              // Associated item ID
  100                                   // Amount
    );

        coinReward.Schedule.ActivationLimit = 1000;
        // well - everything must be parsed of course.. 
        Mission pointMission = new RecordMission(
          i_LevelID + "PointMission" + i_Index + "_ID",                          // ID
          "Point Mission " + i_Index,                           // Name
          new List<Reward>() { coinReward },            // Rewards
          i_ScoreID,                              // Associated score
          i_Value                                           // Desired record                                         // Desired record 
    );
        return pointMission;
    }


    //
    // Various event handling methods
    //



    //
    // Initialize all of SOOMLA's modules
    //
    void Start()
    {


        // Setup event handlers
        // private static LevelUpEventHandler handler = new LevelUpEventHandler();
        // ProfileEvents.OnLoginFinished += onLoginFinished;

        //      world = createMainWorld();
        //// MOUDULES
        //SoomlaHighway.Initialize();
        //// SoomlaStore.Initialize(new ExampleAssets());
        //// SoomlaProfile.Initialize();
        //SoomlaLevelUp.Initialize(createMainWorld());
    }
}
