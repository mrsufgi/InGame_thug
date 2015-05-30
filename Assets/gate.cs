using UnityEngine;
using System.Collections;

public class gate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnTriggerEnter2D(Collider2D other) 
	{

		if (other.tag == "Creature") {
			Debug.Log (other.name);
			Animator anim = gameObject.GetComponent<Animator> ();
			anim.SetTrigger ("StartGateAnimation");
			anim.SetTrigger (0);
			Debug.Log (anim.GetAnimatorTransitionInfo (0)); 
		}
	}
}
