using UnityEngine;
using System.Collections;

public class gateController : MonoBehaviour {

	//public enum_Side side;
	private Done_GameController gameController;
	private GameObject gameControllerObject;
	
	void Start ()
	{
		 gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
//		if (coll.gameObject.tag == "creature_right") {
//			gameController = gameControllerObject.GetComponent <Done_GameController> ();
//			gameController.AddScore (10);
//		}
//
//		if (coll.gameObject.tag == "creature_left") {
//			gameController = gameControllerObject.GetComponent <Done_GameController> ();
//			gameController.AddScore (10);
//		}
		
	}
}
