using UnityEngine;
using System.Collections;

public class openSceneManager : MonoBehaviour {
    public int LevelID;

	// Use this for initialization
	void Start () {


			AudioSource audio = GetComponent<AudioSource>();
			audio.volume = 1;
			audio.Play();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
	}

	void StartGame ()
	{
		Application.LoadLevel (LevelID);				
	}

}
