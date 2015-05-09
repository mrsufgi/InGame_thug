using UnityEngine;
using System.Collections;

public class LevelConfiguration : MonoBehaviour {
	
//	public GameObject[] hazards;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public GameObject[] gates;
	public GameObject pointsLeft;
	public GameObject pointsRight;
	public int levelPointsTarget = 100;



	public int[] frequency; //array of creatures for this level [prefab][percentage of 100%] 
	//!the higher the precentage - the more this obejct will be shown
	public GameObject[] creatures;//array of bonuses for this level

    /* csv */
    public int gameLevel;
    private string fileData;
    private string lines;
    private string lineData;
//    private string path = "C:\\WorkSpace\\Unity\\GitHub\\Beta\\InGame_thug\\Assets\\Thugs.csv";
    private string[] levelEntries;
    private string[] levelLines;
    private TextAsset textAsset;
    private int speed;
    private string creaturesString;

	
	// Use this for initialization
	void Start () {
//        /* csv */
//        // read in a super long string w/ everything in the file
//        fileData = System.IO.File.ReadAllText(path);
//        lines = fileData.Replace("\r\n", "").Replace(" ", "").ToLower();
//        levelLines = lines.Split("\n"[0]);


        //Debug.Log("level number 1: " + levelLines[1]);
        //Debug.Log("level number 2: " + levelLines[2]);

//        levelEntries = levelLines[gameLevel].Split(new[] { ',' });
        //Create an array of long strings for each of what would look like rows if you opened the .csv in excel.  The seperator is basically when the data ends in the row.  new[] creates a new string in the lines array.  Lines.length now equals the number of "rows" in the .csv  
        //levelEntries = levelLines[gameLevel].Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        //Debug.Log("level number: " + levelEntries[0]);
//        speed = System.Convert.ToInt32(levelEntries[1]);
        //Debug.Log("speed: " + levelEntries[1]);
//        creaturesString = levelEntries[2];
        //Debug.Log("creatures: " + levelEntries[2]);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
