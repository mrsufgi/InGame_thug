using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla.Highway;
using Soomla;
using Soomla.Store;
using Soomla.Profile;
using System.Collections.Generic;
using System.Linq;

public class InitialWorld 
{

    private World world;

    public World World
    {
        get
        {
            return world;
        }

        set
        {
            world = value;
        }
    }


<<<<<<< Updated upstream
    //
    // Utility method for creating the game's worlds
    // and levels hierarchy
    //
    private World createMainWorld()
    {
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

        /** Scores **/

        Score pointScore = new Score(
          "pointScore_ID",                            // ID
          "Point Score",                              // Name
          true                                        // Higher is better
        );

        Score gasCoins = new Score(
          "gasCoins_ID",                           // ID  
          "gasCoins Score",                             // Name
          true                                        // Higher is better
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

 
        // mission that can happen during the entire game session
        //XXXX.Schedule = Schedule.AnyTimeOnce();

        // Once users finish Jungle world, they can continue to Desert world.
        Gate blueGate = new WorldCompletionGate(
          "redGate_ID",                            // Item ID
          blueWorld.ID                              // Associated world ID
        );
        redWorld.Gate = blueGate;

        // See private function below
        AddGatesToWorld(blueWorld);
        AddGatesToWorld(redWorld);


        /** Add Worlds to Initial World **/
        mainWorld.AddInnerWorld(blueWorld);
        mainWorld.AddInnerWorld(redWorld);

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

        public World GetInitialWorld()
    {
        return world;
    }

    //
    // Initialize all of SOOMLA's modules
    //
    void Start()
    {


        // Setup event handlers
        // private static LevelUpEventHandler handler = new LevelUpEventHandler();
        // ProfileEvents.OnLoginFinished += onLoginFinished;

        world = createMainWorld();
        //// MOUDULES
        //SoomlaHighway.Initialize();
        //// SoomlaStore.Initialize(new ExampleAssets());
        //// SoomlaProfile.Initialize();
        //SoomlaLevelUp.Initialize(createMainWorld());
    }
=======
//   
//    //
//    // Utility method for creating the game's worlds
//    // and levels hierarchy
//    //
//    private World createMainWorld()
//    {
//        /** Worlds **/
//
//        // Initial world
//        World mainWorld = new World(
//          "main_world", null, null, null,
//          new List<Mission>() { coconutMission, likeMission }
//        );
//
//        World blueWorld= new World(
//          "blueWorld_ID",                             // ID
//          null, null, null,                           // Gate, Inner worlds, Scores
//          new List<Mission>() { statusMissionJungle } // Missions
//        );
//
//        World redWorld = new World(
//          "redWorld_ID",                              // ID
//          null, null, null,                           // Gate, Inner worlds, Scores
//          new List<Mission>() { statusMissionDesert } // Missions
//        );
//
//        /** Scores **/
//
//        Score pointScore = new Score(
//          "pointScore_ID",                            // ID
//          "Point Score",                              // Name
//          true                                        // Higher is better
//        );
//
//        Score gasCoins = new Score(
//          "bananaScore_ID",                           // ID  
//          "Banana Score",                             // Name
//          true                                        // Higher is better
//        );
//
//        /** Add Worlds to Initial World **/
//        mainWorld.AddInnerWorld(jungleWorld);
//        mainWorld.AddInnerWorld(desertWorld);
//
//        return mainWorld;
//    }
//
//    //
//    // Various event handling methods
//    //
// 
//    public void onLevelStarted(Level level)
//    {
//        SoomlaUtils.LogDebug("TAG", "Level started: " + level.toJSONObject().print());
//    }
//
//
//    //
//    // Initialize all of SOOMLA's modules
//    //
//    void Start()
//    {
//        
//
//        // Setup event handlers
//
//        // ProfileEvents.OnLoginFinished += onLoginFinished;
//        LevelUpEvents.OnLevelStarted += onLevelStarted;
//
//        // MOUDULES
//        SoomlaHighway.Initialize();
//      // SoomlaStore.Initialize(new ExampleAssets());
//      // SoomlaProfile.Initialize();
//        SoomlaLevelUp.Initialize(createMainWorld());
//    }
>>>>>>> Stashed changes
}
