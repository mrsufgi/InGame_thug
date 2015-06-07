using UnityEngine;
using System.Collections;

public class openSceneManager : MonoBehaviour {

	//public float startWait = 5;
	public AudioClip startScreenClip;
    public int LevelID;

	// Use this for initialization
	void Start () {
		if (startScreenClip != null) {
			AudioSource.PlayClipAtPoint (startScreenClip, transform.position);
		}
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
