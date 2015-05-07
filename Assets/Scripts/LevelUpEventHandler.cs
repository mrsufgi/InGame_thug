using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla;

public class LevelUpEventHandler
{

    // Constructor - Subscribes to potential events.
    public LevelUpEventHandler()
    {
        LevelUpEvents.OnWorldCompleted += onWorldCompleted;
        LevelUpEvents.OnMissionCompleted += onMissionCompleted;
        CoreEvents.OnRewardGiven += onRewardGiven;
    }

    public void onWorldCompleted(World world)
    {
        // Implemented in the relevant sections below.
    }

    public void onMissionCompleted(Mission mission)
    {
        // Implemented in the relevant sections below.
    }

    public void onRewardGiven(Reward reward)
    {
        // Implemented in the relevant sections below.
    }
}