using UnityEngine;
using System.Collections;

public class TimerEvents : MonoBehaviour {
	
	// TIMER EVENT HANDLERS
	
	public delegate void TimerHandler(float deltaTime);
	
	public static event TimerHandler onAddTime;
	public static event TimerHandler onSubstractTime;
	
	// ADD/SUB by this value should change dynamically through lvl setting.
	// MAYBE 
	public float deltaTime;
	
	
	public static void addTimeToTimer(float deltaTime) 
	{
		if (onAddTime != null)
			onAddTime (deltaTime);
	}
	
	public static void substractTimeFromTimer(float deltaTime) 
	{
		if (onSubstractTime != null)
			onSubstractTime (deltaTime);
	}
	
	public void OnGUI()
	{
		/*if (GUI.Button (new Rect (20, 20, 200, 30), "Add Time")) {
			addTimeToTimer (deltaTime);
		}

		if (GUI.Button (new Rect (20, 70, 200, 30), "Subtact Time")) {
			substractTimeFromTimer (deltaTime);
		}*/
		
	}
	
	
}