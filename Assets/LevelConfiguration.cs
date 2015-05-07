using UnityEngine;
using System.Collections;

public class CreatureFreqClass
{
	public GameObject go {get;set;}
	public int frequenct {get;set;}
}

public class LevelConfiguration : MonoBehaviour {
	
//	public GameObject[] hazards;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;



	public CreatureFreqClass[] creatures; //araray of creatures for this level [prefab][percentage of 100%] 
	//!the higher the precentage - the more this obejct will be shown
	public int[] creature_Bonus_1;//araray of bonuses for this level


	
		// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
