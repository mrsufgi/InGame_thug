using UnityEngine;
using System.Collections;

public class increaseScaleScript : MonoBehaviour
{

	public float scaleIncreaseY;
	public float scaleIncreaseX;
	private float nextActionTime = 0.0f;
	public float period = 0.1f;

	// Use this for initialization
	void Start ()
	{
	
	}
		
	void Update ()
	{
		if (Time.time > nextActionTime) {
			nextActionTime += period; 
			transform.localScale += new Vector3 (scaleIncreaseX, scaleIncreaseY, 0);
			scaleIncreaseX *=-1;
			scaleIncreaseY *=-1;

		}

	}
}
