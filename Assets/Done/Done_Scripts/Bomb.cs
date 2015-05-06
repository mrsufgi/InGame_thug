using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	public int scoreValue;
	public GameObject explosion;
	private Done_GameController gameController;


	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
			gameController = gameControllerObject.GetComponent <Done_GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision other)
	{

//		gameController.AddScore (scoreValue);	
//		if (explosion != null)
//			{
//				Instantiate(explosion, transform.position, transform.rotation);
//			}
//		Destroy (other.gameObject);	
//		Destroy (gameObject);
		}


	void OnMouseDown(){
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
		gameController.GameOver ();
		Destroy (gameObject);
	}
}
