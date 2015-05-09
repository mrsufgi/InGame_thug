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

    void OnDestroy()
    {
        if (!swiped)
        {
            print("dequeue now");
            if (levelManager.q.Count != 0)
            levelManager.q.Dequeue();
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

					Instantiate(levelManager.levelCongif.pointsRight,
					            this.transform.position,
					            Quaternion.identity);
					Debug.Log("here");
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
						Instantiate(explosion, transform.position, transform.rotation);
					}
                Destroy (gameObject);
				} else{
					if(side == enum_Side.side_left) { 		
					timerGameObject.increaseTimeRemaining(timeBonus);	
					Instantiate(levelManager.levelCongif.pointsLeft,
					            this.transform.position,
					            Quaternion.identity);
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
