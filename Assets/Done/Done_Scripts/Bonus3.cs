using UnityEngine;
using System.Collections;

public class Bonus3 : MonoBehaviour {
	public int scoreValue;
	public GameObject explosion;
	public Sprite s1;

	private Done_GameController gameController;
	private Timer timerGameObject;
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");		
		gameController = gameControllerObject.GetComponent <Done_GameController>();

		GameObject timer = GameObject.FindGameObjectWithTag ("Timer");
		timerGameObject = timer.GetComponent <Timer>();

		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter (Collision other)
	{

	}
	
	
	void OnMouseDown(){
		timerGameObject.fillTimer (); //load timer to full
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}
}
