using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
	public GameObject gameOverMenu;
	public GameObject[] hazards;
	public Vector3 spawnValues;
//	public int hazardCount;
	public float spawnWait;
	public float startWait;
//	public float waveWait;
	
	public Text scoreText;
	public Text scoreGameOverText;
	public Text highText;
	public Text restartText;
	public Text gameOverText;

    
	public int creature_R_Vol;
	public int creature_L_Vol;
	public int creature_Bonus_1;
	public int creature_Bonus_2;
	public int creature_Bonus_3;
	public int creature_Surprise;
	public int creature_Bomb;

    private CreatureQueue q;

    private bool gameOver;
	private bool restart;
	private int score=0;
	private int[] numSign;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		numSign = new int[]{1,-1};
        q = GameObject.FindGameObjectWithTag("CreatureQueue").GetComponent<CreatureQueue>();
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
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
//			for (int i = 0; i < hazardCount; i++)
			while(!gameOver)
			{
				rand = Random.Range (0,2);
				hazard = hazards [0];
				//-R creature
				if(rand < creature_R_Vol) //-R creature
					hazard = hazards [0];

				//-L creature
				if(rand >= creature_R_Vol && rand <(creature_L_Vol+creature_R_Vol))
				   hazard = hazards [1];
				//Bonus 1
				if(rand >= creature_L_Vol+creature_R_Vol && rand <(creature_L_Vol+creature_R_Vol+creature_Bonus_1))
				   hazard = hazards [2];
                //Bonus 2
                if (rand >= creature_L_Vol + creature_R_Vol + creature_Bonus_1 && rand < (creature_L_Vol + creature_R_Vol + creature_Bonus_1 + creature_Bonus_2))
                    hazard = hazards[3];
                //Bonus 3
                if (rand >= creature_L_Vol + creature_R_Vol + creature_Bonus_1 + creature_Bonus_2 &&
                   rand < (creature_L_Vol + creature_R_Vol + creature_Bonus_1 + creature_Bonus_2 + creature_Bonus_3))
                    hazard = hazards[4];
                //Surprise
                if (rand >= creature_L_Vol + creature_R_Vol + creature_Bonus_1 + creature_Bonus_2 + creature_Bonus_3 &&
                   rand < (creature_L_Vol + creature_R_Vol + creature_Bonus_1 + creature_Bonus_2 + creature_Bonus_3 + creature_Surprise))
                    hazard = hazards[5];
                //Bomb
                if (rand >= creature_L_Vol + creature_R_Vol + creature_Bonus_1 + creature_Bonus_2 + creature_Bonus_3 + creature_Surprise &&
                   rand <= (creature_L_Vol + creature_R_Vol + creature_Bonus_1 + creature_Bonus_2 + creature_Bonus_3 + creature_Surprise + creature_Bomb))
                    hazard = hazards[6];

                //	GameObject hazard = hazards [Random.Range (0, hazards.Length)];

                //				if(hazard.tag=="bomb"){
                //					//generate wall at right or left of screen
                //					 spawnPosition = new Vector3 ((numSign[Random.Range(0,numSign.Length)] * (spawnValues.x ))
                //					                                                  , spawnValues.y, spawnValues.z);	
                //				}

                spawnPosition = new Vector3
					(Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			
				Quaternion spawnRotation = Quaternion.identity;
				q.Enqueue((GameObject) Instantiate (hazard, spawnPosition, spawnRotation));
				yield return new WaitForSeconds (spawnWait);
			}

			//yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
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