using UnityEngine;
using System.Collections;

public class TutorialSceneManager : MonoBehaviour {
	
	public AudioClip startScreenClip;

	// Use this for initialization
	
	void Start () {
		if (startScreenClip != null) {
			AudioSource.PlayClipAtPoint (startScreenClip, transform.position);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void goToMainMenuScene()
	{
		Application.LoadLevel ("mainMap");
	}

}
