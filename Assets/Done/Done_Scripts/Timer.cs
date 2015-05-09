using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float timeRemaining = 100f;
	public float maxTime = 1000f;
//	public Scrollbar sb; 

	public float timeToDecrease;
	private LevelManager gameController;

	public GameObject panel;
	private RectTransform rt ;


	void Start () {
//		sb.size = 1;
		rt = panel.GetComponent<RectTransform>();   

		InvokeRepeating ("decreaseTimeRemaining", 1.0f, 0.1f);
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <LevelManager>();
		timeRemaining = maxTime;
	}


	void Update()
	{
		if (timeRemaining == 0 )
		{
			gameController.GameOver();
		}
	}

	void decreaseTimeRemaining()
	{

		if (timeRemaining == 0) {
			gameController.GameOver ();
		} else {
			timeRemaining -= timeToDecrease;

			float timeRemainingRelative = timeRemaining / maxTime;
			int width = (int) (timeRemainingRelative * rt.rect.width);
//			Debug.Log ("timeRemaining : " + timeRemaining  + " maxTime" + maxTime);
			
			rt.sizeDelta = new Vector2( width, rt.sizeDelta.y);
		}
	}

	public void increaseTimeRemaining(float timeToAdd)
	{
		if (timeRemaining <= maxTime)
		timeRemaining += timeToAdd;
	}

	public void fillTimer()
	{
		timeRemaining = maxTime;
	}
	// Update is called once per frame
//	void Update () {
//		
//	}
//
//	public void Awake(){
//		TimerEvents.onAddTime += this.AddTime ();
//		TimerEvents.onSubstractTime += this.SubTime ();
//
//	}


}
