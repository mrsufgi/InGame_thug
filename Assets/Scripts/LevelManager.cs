using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Soomla.Levelup;

public class LevelManager : MonoBehaviour
{
	public LevelConfiguration levelCongif;
	private static int level=3;

    /* GUI */
    //	public GameObject gameOverMenu;
    private Score PointScore;
    public static int currentLevelIndex = 1;
    public static Level CurrentLevel = null;
    public Text scoreText;
	public Text pointsMission;  //from mission canvas
    public GameObject panelMissionDisplay; 
	public GameObject panelTimesUp; 	
	public Text scoreTimesUpText;
	public Text timesUpText;
	public Text endLevelBtnTxt;

	public AudioClip startLevelSound;
    public AudioClip gameplaySound;
	//	public Text highText;
//	public Text restartText;

	   	
    private bool isGameStopped=false;
    public GameObject pauseMenu;				// The pause menu UI element to be activated on pause
    private bool paused = false;				// The boolean value to keep track of whether or not the game is currently paused
	
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
	private float directionChangeVariable = 1.0f; //changes every time a creature is creates si that they would apear right or left to the screen center

	void Start ()
	{
        // Soomla stuff // 
        PointScore = CurrentLevel.GetSingleScore();
        print(PointScore.Latest);
        foreach (Mission m in CurrentLevel.Missions)
        {
            m.Schedule.Approve(5);
        }

		gameOver = false;
		timer.gameObject.SetActive(false);
		//End Panel
		panelTimesUp.SetActive (false);
		scoreTimesUpText.text = "";

		//Open Pnanel
		pointsMission.text = getPointsTarget ().ToString ();

		UpdateScore ();

		creaturesArraySize = 10;
		spawnValues = levelCongif.spawnValues;
		spawnWait = levelCongif.spawnWait;
		startWait = levelCongif.startWait;
		
		locateGates ();
		
		creaturesfrequencies = levelCongif.frequency;
		creaturesType = levelCongif.creatures;
		creatures = new GameObject[creaturesArraySize];
		getFrequenciesOfCreatures ();

		q = new Queue<Creature>();
        //startLevel();//TODO:CHANGE IT - JUST FOR TESTING
	}

	public void startLevel()
	{
        //Soomla
        CurrentLevel.Start();
        //

		timer.gameObject.SetActive(true);
		Time.timeScale = 1;
		panelMissionDisplay.SetActive (false);		
		AudioSource.PlayClipAtPoint (startLevelSound, transform.position);
        AudioSource.PlayClipAtPoint(gameplaySound, transform.position);
        
        if (panelMissionDisplay != null) {
		    panelMissionDisplay.SetActive(false);
        }

		timer.startTimer ();
		StartCoroutine (SpawnWaves ());
	}
		
	public void nextLevel()
	{
		level++;
		Application.LoadLevel (level);
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

			Quaternion spawnRotation = Quaternion.identity;
		    spawnRotation = Quaternion.identity;
			GameObject creature = (GameObject)Instantiate(gate, spawnPosition, spawnRotation);		
		}
	}

	IEnumerator SpawnWaves ()
	{

//		yield return new WaitForSeconds (1);

		int rand;
		GameObject curCreature;
		Vector3 spawnPosition;
		Debug.Log ("0");
		while (true)
		{
			Debug.Log ("1");
			while(!gameOver)
			{
				Debug.Log ("2");
				rand = Random.Range (0,10);
				curCreature = creatures [rand];

				directionChangeVariable *= -1;
                spawnPosition = new Vector3
					( spawnValues.x + directionChangeVariable * 0.5f, spawnValues.y, spawnValues.z);
			
				Quaternion spawnRotation = Quaternion.identity;
				GameObject creature = (GameObject)Instantiate(curCreature, spawnPosition, spawnRotation);
                q.Enqueue(creature.GetComponent<Creature>());
				yield return new WaitForSeconds (spawnWait);
			}
            if (true)
            {
                CurrentLevel.End(true);
                print("youasokjakslj;klsjg");
                break;
            }
            else
            {
                CurrentLevel.End(false);
                print("yo");
                break;
            }
            //yield return new WaitForSeconds (waveWait);

        }
	}

    	
	public void AddScore (int newScoreValue)
	{
		if (newScoreValue > 0)
        {
            PointScore.Inc(newScoreValue);
            UpdateScore();
        }
	}
	
	void UpdateScore ()
	{
		scoreText.text =  ""+ PointScore.GetTempScore();
	}
	
	public void GameOver ()
	{

        timer.gameObject.SetActive(false);
		panelTimesUp.SetActive (true);

		string outputToUser;
		string outputScoreToUser;

        if (PointScore.HasTempReached(getPointsTarget())) {
            outputScoreToUser = "You Got: " + PointScore.GetTempScore();
			outputToUser = "Great Job" ;
			endLevelBtnTxt.text= "Done";
            CurrentLevel.End(true);
        } else {
			endLevelBtnTxt.text = "Play Again";
			outputToUser = "Mission Missed" ;
			outputScoreToUser = "Mission: " +
				levelCongif.levelPointsTarget + 
					"\nYou Got: " + PointScore.GetTempScore();
            CurrentLevel.End(false);
        }

		timesUpText.text = outputToUser;
		scoreTimesUpText.text =  outputScoreToUser;

//		string highScoreKey = "HighScore";
//		int highScore = PlayerPrefs.GetInt (highScoreKey, 0);
//		if (score > highScore) {//update score
//			PlayerPrefs.SetInt (highScoreKey, score);
//			PlayerPrefs.Save();
//		}

		gameOver = true;
		StartCoroutine (wait ());
		Time.timeScale = 0;
	}

    // WHAT? 
	IEnumerator wait(){
		yield return new WaitForSeconds(10.0f);
	}

	public void reload(){
		Time.timeScale = 1;
		Application.LoadLevel (1);
	}

    public void Play()
    {
        Time.timeScale = 1;
        Debug.Log("play pressed");
        // Deactivate the pause menu UI element
        if (pauseMenu != null)
            pauseMenu.SetActive(false);

        paused = false;
        isGameStopped = false;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Debug.Log("pause pressed");
        // Activate the pause menu UI element
        if (pauseMenu != null)
            pauseMenu.SetActive(true);

        paused = true;
        isGameStopped = true;
        //spriteRenderer.sprite = pause_sprite1_Pause; // set the sprite to sprite1- pause
    }

	public int getPointsTarget()
	{
		return levelCongif.levelPointsTarget;
	}

}

