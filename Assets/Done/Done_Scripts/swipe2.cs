
using UnityEngine;
using System.Collections;

public class SwipeGesture : MonoBehaviour {
	Vector2 startPosition;
	float startTime;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
			Vector2 endPosition = Input.GetTouch(0).position;
			Vector2 delta = endPosition - startPosition;
			
			float dist = Mathf.Sqrt(Mathf.Pow(delta.x, 2) + Mathf.Pow (delta.y, 2));
			float angle = Mathf.Atan (delta.y/delta.x) * (180.0f/Mathf.PI);
			float duration = Time.time - startTime;
			float speed = dist/duration;
			
			// Left to right swipe
			if (startPosition.y < endPosition.y) {
				if (angle < 0) angle = angle * 1.0f;
				Debug.Log ("Distance: " + dist + " Angle: " + angle + " Speed: " + speed);
				
				if (dist > 300 && angle < 10 && speed > 1000) {
					// Do something related to the swipe
				}
			}
		}
		
		if (Input.touchCount > 0  && Input.GetTouch (0).phase == TouchPhase.Began) {
			startPosition = Input.GetTouch(0).position;
			startTime = Time.time;
		}
	}
}
