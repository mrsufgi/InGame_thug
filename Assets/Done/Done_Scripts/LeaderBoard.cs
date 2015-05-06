using UnityEngine; 
using UnityEngine.UI;
using System.Collections;

public class LeaderBoard : MonoBehaviour { 
	
	public static int highScore;
	public static string highScoreKey = "HighScore";
	Text text;

	void Awake() {
		text = GetComponent<Text> ();
	}

	void Start(){
		highScore = PlayerPrefs.GetInt(highScoreKey,0);
		//use this value in whatever shows the leaderboard.
	}

	// Display High score
	void Update () {
		text.text = "High Score: " + highScore;
	}

	// Update high score 
	public static void SaveHighScore(int score) {
		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt(highScoreKey, score);
			PlayerPrefs.Save();
		}
	}

	// Override high score 
	public static void OverrideHighScore(int score) {
			highScore = score;
			PlayerPrefs.SetInt(highScoreKey, score);
			PlayerPrefs.Save();
	} 

	// Reset high score
	public static void ResetHighScore() {
		highScore = 0;
		OverrideHighScore (highScore);
	}

	
}