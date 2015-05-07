using UnityEngine;
using System.Collections;

public enum enum_Side{
	side_left = 0,
	side_right = 1
};

public class Done_DestroyByBoundarySides : MonoBehaviour
{
	public enum_Side side;
	private LevelManager gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <LevelManager>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other) 
	{

      }
	
}