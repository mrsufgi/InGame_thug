using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        // if you plan on listening to the spawn/despawn events, Start is a good time to add your listeners.
        TrashMan.recycleBinForGameObject(Creatures[0].creaturePrefab).onSpawnedEvent += go => Debug.Log("spawned object: " + go);
        TrashMan.recycleBinForGameObject(Creatures[0].creaturePrefab).onDespawnedEvent += go => Debug.Log("DEspawned object: " + go);


        var Spawner = Observable.FromCoroutine(SpawnCreatures).Subscribe();
    }

    // Defines a spawn position.
    [System.Serializable]
    public class SpawnPosition
    {
        public Transform Position;
        public bool Active;
        public float minDelay;
        public float maxDelay;
        public float startDelay;
        //public short maxAmount;
    };

    public SpawnPosition spawnPosition;

    //========Enemy Types========
    [System.Serializable]
    public class CreatureType
    {
        public GameObject creaturePrefab;
        public int[] spawnPoint; // index for spawnPoint we want to spawn this creature.
        public float ratio;
    };

    public List<CreatureType> Creatures;

    public void Update()
    {
      //  print(RandomizedSelectionByRation());
    }

    //TODO: Add smarter delay systems.
    //TODO: Consider speed factor. It should  be rational to the delay (small delay in high speed can make clusters. 
    //TODO: Set limits to input (input / delay)
    private float RandomizedDelay()
    {
        return Random.Range(spawnPosition.minDelay, spawnPosition.maxDelay);
    }

    private int RandomizedSelectionByRation()
    {
        int result = 0;
        float totalRatio = 0;

        for (int i = 0; i < Creatures.Count; i++)
        {
            totalRatio += Creatures[i].ratio;
        }

        float randVal = Random.Range(0, totalRatio);
        for (int i = 0; i < Creatures.Count; i++)
        {
            if (randVal < Creatures[i].ratio)
            {
                result = i;
                break;
            }

            randVal -= Creatures[i].ratio;
        }
        return result;
    }



    IEnumerator SpawnCreatures()
    {
        yield return new WaitForSeconds(spawnPosition.startDelay);
        while (true) {
            
            // choose prefab to spawn
            int indexForCreation = RandomizedSelectionByRation();
            print(indexForCreation);

            // choose x cooridinate for spawn position
            float delta = Random.Range(-3, 3);

            // TODO:// change to something cheaper then new Vector3()
            Vector3 realPosition = new Vector3(spawnPosition.Position.transform.position.x + delta, spawnPosition.Position.transform.position.y, spawnPosition.Position.transform.position.z);

            // spawn and save reference.
            var newObj = TrashMan.spawn(Creatures[indexForCreation].creaturePrefab, realPosition);
            TrashMan.despawnAfterDelay(newObj, Random.Range(10f, 20f));

            //delay next spawn with random delay  
            yield return new WaitForSeconds(RandomizedDelay());


        }
        
    }
}

