using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public SpawnPosition spawnPosition;
    // Use this for initialization
    void Start () {
	
	}

    // Defines a spawn position.
    [System.Serializable]
    public class SpawnPosition
    {
        public Transform Position; 
        public bool Active;         
        public float minDelay;      
        public float maxDelay;      
        //public short maxAmount;
    };

    //========Enemy Types========
    [System.Serializable]
    public class CreatureType
    {
        public GameObject creaturePrefab;
        public int[] spawnPoint; // index for spawnPoint we want to spawn this creature.
        public float ratio;
    };
    
    public List<CreatureType> Creatures;


    //TODO: Add smarter delay systems.
    //TODO: Consider speed factor. It should  be rational to the delay (small delay in high speed can make clusters. 
    //TODO: Set limits to input (input / delay)
    private float RandomizedDelay()
    {
       return Random.Range(spawnPosition.minDelay, spawnPosition.maxDelay);
    }


}
