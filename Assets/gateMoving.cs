using UnityEngine;
using System.Collections;

public class gateMoving : MonoBehaviour {
    public Vector3 pointB;
	// Use this for initialization
	IEnumerator Start () {
        var pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
        }
	
	}

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
	// Update is called once per frame
	void Update () {
	
	}

	void  OnTriggerEnter2D(Collider2D other) 
	{

		//Blue
		if (other.tag == "Creature" && other.name=="Creature_1(Clone)" && this.tag=="gate_L") {
			Debug.Log (other.name);
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
