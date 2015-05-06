using UnityEngine;
using System.Collections;

public class Swipe : MonoBehaviour {


	void OnMouseDown (){
//		Vector3 wp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//		Vector2 touchPos = new Vector2 (wp.x, wp.y);
//		Debug.Log ("touchPos" + touchPos);
//		Rigidbody rb = GetComponent<Rigidbody> ();
//
//		if (Input.GetMouseButtonDown (0))
//			rb.AddForce (-transform.right * 3000);
	}

	public float speed = 1; // speed in meters per second
	public float smooth = 2.0F;
	public float tiltAngle = 30.0F;
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0 && 
			Input.GetTouch (0).phase == TouchPhase.Moved) {
			
			
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			
			Vector3 touchPosition = new Vector3();
			
			touchPosition.Set (touchDeltaPosition.x, 
			                  transform.position.y, 
			                  touchDeltaPosition.y);
			
			
			// Move object across XY plane
			this.transform.position = Vector3.Lerp (transform.position,
			                                  touchPosition, 
			                                  Time.deltaTime * speed);
		}
	}


} 