using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static int score; // Holds current session score
    public static int highScore = 0; //
    public static string highScoreKey = "HighScore";
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "Score: " + score;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    void onDisable()
    {
        LeaderBoard.SaveHighScore(score);
    }
}
