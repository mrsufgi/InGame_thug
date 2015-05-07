﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
	public LevelManager levelManager;

	/* GUI */	
	public GameObject gameOverMenu;
	public Text scoreText;
	public Text scoreGameOverText;
	public Text highText;
	public Text restartText;
	public Text gameOverText;
	   	
    //Queue that holds game object - yet accepts only gameObject with tag = "Creature"
    public Queue<Creature> q;

	/* Level Depended vars */
	private CreatureFreqClass[] creaturesfrequencies; //[creature][freq = 1 to 10]
	private GameObject[] creatures; 
	private Vector3 spawnValues;
	private float spawnWait;
	private float startWait;
	/* General */
    private bool gameOver;
	private bool restart;
	private int score = 0;
	private int[] numSign;
	private int creaturesArraySize;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		creaturesArraySize = 10;

		UpdateScore ();
		spawnValues = levelManager.spawnValues;
		spawnWait = levelManager.spawnWait;
		startWait = levelManager.startWait;

		creaturesfrequencies = levelManager.creaturesfrequencies;
		creatures = new GameObject[creaturesArraySize];
		getFrequenciesOfCreatures ();

		StartCoroutine (SpawnWaves ());
		numSign = new int[]{1,-1};
        q = new Queue<Creature>();
    }

	private void getFrequenciesOfCreatures()
	{
		int index = 0;
		for (int i = 0; i < creaturesfrequencies.Length; i++) 
		{
			for (int j = 0; j < creaturesfrequencies[i,1]; j++) 
			{
				/*if creature x has frewquency 6 - add it 6 times to creatures array*/
				if(index < creatures.Length)
				{
					creatures[index] = creaturesfrequencies[i,0];
					index++;
				} else
				{
					Debug.Log(" !!  Error in index value in getFrequenciesOfCreatures() method");
				}
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		int rand;
		GameObject hazard;
		Vector3 spawnPosition;
		while (true)
		{
			while(!gameOver)
			{
				rand = Random.Range (0,10);
				hazard = creatures [rand];

                spawnPosition = new Vector3
					(Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			
				Quaternion spawnRotation = Quaternion.identity;
                GameObject creature = (GameObject)Instantiate(hazard, spawnPosition, spawnRotation);
                q.Enqueue(creature.GetComponent<Creature>());
				yield return new WaitForSeconds (spawnWait);
			}

			//yield return new WaitForSeconds (waveWait);
		}
	}

    // export Score stuff into a different class.. really.. 	
	public void AddScore (int newScoreValue)
	{
		int tempScore = score;
		if ((tempScore += newScoreValue) < 0)//cannot be negative
			return;

		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text =  ""+score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		scoreGameOverText.text =  "Score: "+score;

		string highScoreKey = "HighScore";
		int highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		if (score > highScore) {//update score
			PlayerPrefs.SetInt (highScoreKey, score);
			PlayerPrefs.Save();
		}

		highText.text =  "High Score: " + highScore;
		gameOver = true;
		StartCoroutine (wait ());

		Time.timeScale = 0;
	
		if(gameOverMenu != null)
			gameOverMenu.SetActive (true);
	}

    // WHAT? 
	IEnumerator wait(){
		yield return new WaitForSeconds(10.0f);
	}

	public void reload(){
		Time.timeScale = 1;
		Application.LoadLevel (1);
	}

}