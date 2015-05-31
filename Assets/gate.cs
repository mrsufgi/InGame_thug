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
		if(other.tag == "Creature")
			Debug.Log(this.tag);

		//Blue
		if (other.tag == "Creature" && other.name=="Creature_1(Clone)" && this.tag=="gate_L") {
			Debug.Log (other.name);
			Animator anim = gameObject.GetComponent<Animator> ();
			anim.SetTrigger ("StartGateAnimation");
//			anim.SetTrigger (0);
			Debug.Log (anim.GetAnimatorTransitionInfo (0)); 
		}
		//Orange
		if (other.tag == "Creature" && other.name =="Creature_2(Clone)" && this.tag=="gate_R") {
			Debug.Log (other.name);
			Animator anim = gameObject.GetComponent<Animator> ();
			anim.SetTrigger ("StartOrangeGateAnimation");
//			anim.SetTrigger (0);
			Debug.Log (anim.GetAnimatorTransitionInfo (0)); 
		}
	}
}
