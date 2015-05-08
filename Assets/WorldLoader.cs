using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using Soomla;

public class WorldLoader : MonoBehaviour {

    bool isOpen;
    bool isComplete;
    // static loader...
    public void World_two_Load()
    {
        if (SoomlaLevelUp.GetWorld("blueWorld_ID").IsCompleted())
        {
            Application.LoadLevel("level");
        } else
        {
            print("fu");
        }
    }

    public void World_one_Load()
    {
      
        Application.LoadLevel("level");

    } 

}
