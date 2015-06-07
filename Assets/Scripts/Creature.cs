using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {

    public bool swiped = false;
    public int bonusModifier;
    
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	
	public enum_Side side;
	public float timeBonus;

	private LevelManager levelManager;
	private Timer timerGameObject;
	public AudioClip[] leftCreatureSounds;
	public AudioClip[] rightCreatureSounds;


    void OnDestroy()
    {
        if (!swiped) {
			print ("dequeue now");
			if (levelManager.q.Count != 0)
				levelManager.q.Dequeue ();
		} else {

 		}
    }
	void Start ()
	{
        GameObject timer = GameObject.FindGameObjectWithTag ("Timer");
		timerGameObject = timer.GetComponent <Timer>();

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			levelManager = gameControllerObject.GetComponent <LevelManager>();
          //  print("set");
		}
		if (levelManager == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Boundary")
		{
			//Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //no animation when missed a creature (hit bottom gate)
			/*if (explosion != null)
			{
				Instantiate(explosion, transform.position, transform.rotation);
			}
			print("dashit");*/
            Destroy (gameObject);
		}

		if (other.tag == "gate_R") {//This is a left side creature - kill
						
			if (side == enum_Side.side_left) { 	
				if (explosion != null) {
					int i  = Random.Range (0, leftCreatureSounds.Length);
					AudioSource.PlayClipAtPoint (leftCreatureSounds [i], transform.position);
					Instantiate (explosion, transform.position, transform.rotation);
				}
     
                Destroy (gameObject);
			} else {
				if (side == enum_Side.side_right) 
				{ 
					GameObject newObject = Instantiate(levelManager.levelCongif.pointsRight,
					                                   transform.position, transform.rotation) as GameObject;
					newObject.transform.position =  this.transform.position + new Vector3(2,-15,0);

					levelManager.AddScore (scoreValue);
                    Destroy (gameObject);
				}
			}
		}
			if (other.tag == "gate_L") 
			{//This is a right side creature - kill			
				if(side == enum_Side.side_right) { 
					if (explosion != null)
					{
					int i  = Random.Range (0, rightCreatureSounds.Length);
					AudioSource.PlayClipAtPoint (rightCreatureSounds [i], transform.position);		
						Instantiate(explosion, transform.position, transform.rotation);
					}
                Destroy (gameObject);
				} else{
					if(side == enum_Side.side_left) { 	

					GameObject newObject = Instantiate(levelManager.levelCongif.pointsLeft,
					                                   transform.position, transform.rotation) as GameObject;
					newObject.transform.position =  this.transform.position + new Vector3(2,-15,0);

					levelManager.AddScore(scoreValue);
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
			levelManager.AddScore(-scoreValue);
			Destroy(other.gameObject);
			Destroy (gameObject);
		}

	}

}
