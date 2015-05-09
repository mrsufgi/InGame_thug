using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float timeRemaining = 100f;
	public float maxTime = 1000f;
	public Text timeText;
	public float timeToDecrease;
	public GameObject panel;

	private LevelManager gameController;
	private RectTransform rt ;
	private float initialWidth;
	
	void Start () {
		rt = panel.GetComponent<RectTransform>();   
		initialWidth = rt.rect.width;
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <LevelManager>();
		timeRemaining = maxTime;
	}

	public void startTimer()
	{
		InvokeRepeating ("decreaseTimeRemaining", 1.0f, 0.25f);
	}

	void Update()
	{
		if (timeRemaining == 0 )
			gameController.GameOver();
	}

	void decreaseTimeRemaining()
	{

		if (timeRemaining == 0) {
			gameController.GameOver ();
		} else {
			timeRemaining -= timeToDecrease;
			//Update Panel
			float timeRemainingRelative = timeRemaining / maxTime;
			int width = (int) (timeRemainingRelative * initialWidth);
			rt.sizeDelta = new Vector2( width, rt.sizeDelta.y);
			timeText.text =  (((int)timeRemaining) ).ToString();
			//			Debug.Log ("timeRemaining : " + timeRemaining  + " maxTime" + maxTime);
			//			Debug.Log("rt.rect.width:  " + rt.rect.width.ToString() + "  width: " +width );
		}
	}

	public void increaseTimeRemaining(float timeToAdd)
	{
		if (timeRemaining <= maxTime)
		timeRemaining += timeToAdd;
	}

	public void fillTimer() {
		timeRemaining = maxTime;
	}
}
