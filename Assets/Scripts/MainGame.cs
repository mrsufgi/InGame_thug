using UnityEngine;
using System.Collections;
using Soomla.Levelup;


public class MainGame : MonoBehaviour {

    private static LevelUpEventHandler handler = new LevelUpEventHandler();
    // Use this for initialization
    void Start () {
	// Initialize Event Handler
   


    // Initialize LevelUp
    World mainWorld = new InitialWorld().World;

        SoomlaLevelUp.Initialize(mainWorld);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
