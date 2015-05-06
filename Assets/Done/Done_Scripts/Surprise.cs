using UnityEngine;
using System.Collections;

public enum E_SurpriseType
{
	e_addScore,
	e_subScore,
	e_addTime,
	e_subTime
};

public class Surprise : MonoBehaviour {
	public int scoreValue;
	public GameObject explosion;
	public float delayTime;
	public Sprite s1;
	public Sprite s2;
	public Sprite s3;
	public Sprite s4;
	private Sprite sprite;
	public int timeToAdd;
	public int pointsToAdd;
	private SpriteRenderer sr;

//	public E_SurpriseType surpriseType;
	private Done_GameController gameController;
	private Timer timerGameObject;
	private E_SurpriseType surpriseType;
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");		
		gameController = gameControllerObject.GetComponent <Done_GameController>();

		GameObject timer = GameObject.FindGameObjectWithTag ("Timer");
		timerGameObject = timer.GetComponent <Timer>();
		 sr = gameObject.GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter (Collision other)
	{

	}
	
	
	void OnMouseDown(){

		surpriseType=(E_SurpriseType)  Random.Range (0, 3);
		switch (surpriseType) {
		case E_SurpriseType.e_addScore:
			sprite = s1;
			break;
		case E_SurpriseType.e_subScore:
			sprite = s2;
			break;
		case E_SurpriseType.e_addTime:
			sprite = s3;
			break;
		case E_SurpriseType.e_subTime:
			sprite = s4;
			break;
		}
		sr.sprite=sprite;

		StartCoroutine(operateBunusFunction ());
	}

	IEnumerator operateBunusFunction ()
	{
		yield return new WaitForSeconds (delayTime);
		Debug.Log ("time's up");
		switch (surpriseType) {
		case E_SurpriseType.e_addScore:
			gameController.AddScore(pointsToAdd);
			break;
		case E_SurpriseType.e_subScore:
			gameController.AddScore(-pointsToAdd);
			break;
		case E_SurpriseType.e_addTime:
			timerGameObject.increaseTimeRemaining(timeToAdd);
			break;
		case E_SurpriseType.e_subTime:
			timerGameObject.increaseTimeRemaining(-timeToAdd);
			break;
		}
		
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}
}
