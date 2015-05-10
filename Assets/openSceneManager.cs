using UnityEngine;
using System.Collections;

public class openSceneManager : MonoBehaviour {

	public float startWait = 5;
	public AudioClip startScreenClip;



	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint (startScreenClip, transform.position);
		StartCoroutine (StartGame());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator StartGame ()
	{
		yield return new WaitForSeconds (startWait);
		Application.LoadLevel (1);				
	}

}
