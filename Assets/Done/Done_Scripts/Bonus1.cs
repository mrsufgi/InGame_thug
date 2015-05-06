using UnityEngine;
using System.Collections;

public class Bonus1 : MonoBehaviour {
	public int scoreValue;
	public GameObject explosion;
	private Done_GameController gameController;

	public Sprite s1;
	public Sprite s2;
	private static int flipShape=1;
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");		
		gameController = gameControllerObject.GetComponent <Done_GameController>();

		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();

		if ((flipShape % 2) == 0) {
			sr.sprite=s1;
		} else {
			sr.sprite=s2;
		}
		flipShape++;
		
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
		gameController.AddScore (scoreValue);
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}
}
