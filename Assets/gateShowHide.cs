using UnityEngine;
using System.Collections;

public class gateShowHide : MonoBehaviour {
    //private GameObject objectToActivate;
    // Use this for initialization
    void Start()
    {
        //objectToActivate = GameObject.FindGameObjectWithTag("gate_R");
        //int level = levelCongif.gameLevel;
        //TODO: uncomment if we want to hide all gates after couple of seconds
        //if (gameObject.activeInHierarchy)
        //    gameObject.SetActive(false);
        StartCoroutine("HideUnhide");
        

    }

    IEnumerator HideUnhide()
    {
        bool toHideGate = true;
        while (true)
        {
            //this.gameObject.SetActive(false);
            yield return (new WaitForSeconds(6));
            gameObject.transform.position = this.transform.position + new Vector3(0, 100, 0);
            yield return (new WaitForSeconds(1));
            Debug.Log("GOTHERE");
            gameObject.transform.position = this.transform.position + new Vector3(0, -100, 0);
            //objectToActivate.SetActive(true);
        }
    }

   
	// Update is called once per frame
	void Update () {
	
	}

	void  OnTriggerEnter2D(Collider2D other) 
	{

		//Blue
		if (other.tag == "Creature" && other.name=="Creature_1(Clone)" && this.tag=="gate_L") {
			//Debug.Log (other.name);
			Animator anim = gameObject.GetComponent<Animator> ();
			anim.SetTrigger ("StartGateAnimation");
		}
		//Orange
		if (other.tag == "Creature" && other.name =="Creature_2(Clone)" && this.tag=="gate_R") {
			Animator anim = gameObject.GetComponent<Animator> ();
			anim.SetTrigger ("StartOrangeGateAnimation"); 
		}
	}
}
