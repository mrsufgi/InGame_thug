using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla.Highway;
using Soomla;
using Soomla.Store;
using Soomla.Profile;
using System.Collections.Generic;

public class InitialWorld : MonoBehaviour {

   
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
          new List<Mission>() { coconutMission, likeMission }
        );

        World blueWorld= new World(
          "blueWorld_ID",                             // ID
          null, null, null,                           // Gate, Inner worlds, Scores
          new List<Mission>() { statusMissionJungle } // Missions
        );

        World redWorld = new World(
          "redWorld_ID",                              // ID
          null, null, null,                           // Gate, Inner worlds, Scores
          new List<Mission>() { statusMissionDesert } // Missions
        );

        /** Scores **/

        Score pointScore = new Score(
          "pointScore_ID",                            // ID
          "Point Score",                              // Name
          true                                        // Higher is better
        );

        Score gasCoins = new Score(
          "bananaScore_ID",                           // ID  
          "Banana Score",                             // Name
          true                                        // Higher is better
        );

        /** Add Worlds to Initial World **/
        mainWorld.AddInnerWorld(jungleWorld);
        mainWorld.AddInnerWorld(desertWorld);

        return mainWorld;
    }

    //
    // Various event handling methods
    //
 
    public void onLevelStarted(Level level)
    {
        SoomlaUtils.LogDebug("TAG", "Level started: " + level.toJSONObject().print());
    }


    //
    // Initialize all of SOOMLA's modules
    //
    void Start()
    {
        

        // Setup event handlers

        // ProfileEvents.OnLoginFinished += onLoginFinished;
        LevelUpEvents.OnLevelStarted += onLevelStarted;

        // MOUDULES
        SoomlaHighway.Initialize();
      // SoomlaStore.Initialize(new ExampleAssets());
      // SoomlaProfile.Initialize();
        SoomlaLevelUp.Initialize(createMainWorld());
    }
}
