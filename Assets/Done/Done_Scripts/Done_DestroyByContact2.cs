using UnityEngine;
using System.Collections;

public class Done_DestroyByContact2 : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;
	public enum_Side side;
	public float timeBonus;
	private Timer timerGameObject;


	void Start ()
	{

		GameObject timer = GameObject.FindGameObjectWithTag ("Timer");
		timerGameObject = timer.GetComponent <Timer>();

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Boundary")
		{
			//Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			if (explosion != null)
			{
				Instantiate(explosion, transform.position, transform.rotation);
			}
			Destroy (gameObject);
		}

		if (other.tag == "gate_R") {//This is a left side creature - kill
						
			if (side == enum_Side.side_left) { 	
				if (explosion != null) {
					Instantiate (explosion, transform.position, transform.rotation);
				}
				Destroy (gameObject);
			} else {
				if (side == enum_Side.side_right) { 
					timerGameObject.increaseTimeRemaining(timeBonus);
					gameController.AddScore (scoreValue);

					Destroy (gameObject);
				}
			}
		}
			if (other.tag == "gate_L") 
			{//This is a right side creature - kill			
				if(side == enum_Side.side_right) { 
					if (explosion != null)
					{
						Instantiate(explosion, transform.position, transform.rotation);
					}
					Destroy (gameObject);
				} else{
					if(side == enum_Side.side_left) { 		
					timerGameObject.increaseTimeRemaining(timeBonus);	
					gameController.AddScore(scoreValue);
						Destroy (gameObject);
					}
				}
			}

		if (other.tag == "bomb") 
		{
			if (explosion != null)
			{
				Instantiate(explosion, transform.position, transform.rotation);
			}
			gameController.AddScore(-scoreValue);
			Destroy(other.gameObject);
			Destroy (gameObject);
		}

	}

}