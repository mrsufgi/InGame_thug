using UnityEngine;
using System.Collections;

public class Surprise1 : MonoBehaviour {

	public GameObject[] prefabs;	
	private Done_GameController gameController;
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");		
		gameController = gameControllerObject.GetComponent <Done_GameController>();

		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter (Collision other)
	{
	}

	void OnMouseDown(){
		GameObject surprise = prefabs [Random.Range (0, prefabs.Length)];
		Instantiate (surprise, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
