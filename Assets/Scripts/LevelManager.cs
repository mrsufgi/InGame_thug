using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
	public LevelConfiguration levelCongif;

	/* GUI */	
//	public GameObject gameOverMenu;
	public Text scoreText;
	public Text pointsMission;  //from mission canvas
	public GameObject panel; 
	/*
	public Text scoreGameOverText;
	public Text highText;
	public Text restartText;
	public Text gameOverText;*/
	   	
    //Queue that holds game object - yet accepts only gameObject with tag = "Creature"
    public Queue<Creature> q;

	/* Level Depended vars */
	private int[] creaturesfrequencies; //[freq = 1 to 10]
	private GameObject[] creaturesType; 
	private GameObject[] creatures; 
	private Vector3 spawnValues;
	private float spawnWait;
	private float startWait;
	/* General */
    private bool gameOver;
	private int score = 0;
	private int creaturesArraySize;
	public Timer timer;

	void Start ()
	{
		pointsMission.text = getPointsTarget ().ToString ();

		gameOver = false;
		//		restartText.text = "";
		//		gameOverText.text = "";
		score = 0;
		creaturesArraySize = 10;
		
		UpdateScore ();
		spawnValues = levelCongif.spawnValues;
		spawnWait = levelCongif.spawnWait;
		startWait = levelCongif.startWait;
		
		locateGates ();
		
		creaturesfrequencies = levelCongif.frequency;
		creaturesType = levelCongif.creatures;
		creatures = new GameObject[creaturesArraySize];
		getFrequenciesOfCreatures ();

		q = new Queue<Creature>();
	}

	public void startLevel()
	{
		panel.SetActive (false);
		timer.startTimer ();
		StartCoroutine (SpawnWaves ());
	}

	private void getFrequenciesOfCreatures()
	{
		/*if creature x has frewquency 6 - add it 6 times to creatures array*/
		int index = 0;
		while (index  < creaturesArraySize) {
			for (int i = 0; i < creaturesfrequencies[index]; i++) 
			{
				creatures[index] =  creaturesType[index];
			}
			index++;
		}
	}

	private void locateGates()
	{
		Vector3 spawnPosition;
		GameObject[] gates = levelCongif.gates;

		foreach (GameObject gate in gates)
		{
			spawnPosition = new Vector3(gate.transform.position.x,
			                            gate.transform.position.y,
			                            gate.transform.position.z);

//			spawnPosition = new Vector3(0,
//			                           0,
//			                          0);
			Quaternion spawnRotation = Quaternion.identity;
		    spawnRotation = Quaternion.identity;
			GameObject creature = (GameObject)Instantiate(gate, spawnPosition, spawnRotation);

			/*Update gate color*/
//			float r,g,b,a;
//			creature.GetComponent<SpriteRenderer>().color = Color(r,g,b,a);			
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		int rand;
		GameObject curCreature;
		Vector3 spawnPosition;
		while (true)
		{
			while(!gameOver)
			{
				rand = Random.Range (0,10);
				curCreature = creatures [rand];

                spawnPosition = new Vector3
					(Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			
				Quaternion spawnRotation = Quaternion.identity;
				GameObject creature = (GameObject)Instantiate(curCreature, spawnPosition, spawnRotation);
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
//		gameOverText.text = "Game Over!";
//		scoreGameOverText.text =  "Score: "+score;

		string highScoreKey = "HighScore";
		int highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		if (score > highScore) {//update score
			PlayerPrefs.SetInt (highScoreKey, score);
			PlayerPrefs.Save();
		}

//		highText.text =  "High Score: " + highScore;
		gameOver = true;
		StartCoroutine (wait ());

		Time.timeScale = 0;
	
//		if(gameOverMenu != null)
//			gameOverMenu.SetActive (true);
	}

    // WHAT? 
	IEnumerator wait(){
		yield return new WaitForSeconds(10.0f);
	}

	public void reload(){
		Time.timeScale = 1;
		Application.LoadLevel (1);
	}

	public int getPointsTarget()
	{
		return levelCongif.levelPointsTarget;
	}

}