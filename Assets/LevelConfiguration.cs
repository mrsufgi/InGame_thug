﻿using UnityEngine;
using System.Collections;

public class LevelConfiguration : MonoBehaviour {
	
//	public GameObject[] hazards;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public GameObject[] gates;



	public int[] frequency; //araray of creatures for this level [prefab][percentage of 100%] 
	//!the higher the precentage - the more this obejct will be shown
	public GameObject[] creatures;//araray of bonuses for this level


	
		// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
