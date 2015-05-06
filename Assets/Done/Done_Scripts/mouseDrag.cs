using UnityEngine;
using System.Collections;

public class mouseDrag : MonoBehaviour {

	Vector3 offset;
	Vector3 screenPoint ;
	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() { 
		Debug.Log ("on mouse down");
		screenPoint = Camera.main.WorldToScreenPoint(target.position);
		
		offset = target.position - Camera.main.ScreenToWorldPoint(
			new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseDrag() { Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
}
