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


        Score gasCoins = new VirtualItemScore(
              "gasCoins_ID",                           // ID  
              "gasCoins Score",                             // Name
              true,                                 // Higher is better
              StoreAssets.COIN_CURRENCY.ID
        );


        /** Missions **/

        // well - everything must be parsed of course.. 
        Mission pointMission = new RecordMission(
          "pointMission_ID",                          // ID
          "Point Mission",                            // Name
          null,            // Rewards
          pointScore.ID,                              // Associated score
          100                                           // Desired record 
        );


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


        /** Add Worlds to Initial World **/
        mainWorld.AddInnerWorld(blueWorld);
        mainWorld.AddInnerWorld(redWorld);

        /** Add gas points**/
        //        gasCoins.StartValue = 1000.0;
        
        mainWorld.AddScore(gasCoins);
        return mainWorld;
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

            // The gates in this Level's GatesListAND are the 2 gates declared above.
            currentLevel.Gate = new GatesListAND(
              "gate_" + world.ID + "_level_" + i.ToString(),                    // ID
              new List<Gate>() { prevLevelCompletionGate }  // List of Gates
            );
        }
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
