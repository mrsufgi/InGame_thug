﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelPauseManager : MonoBehaviour {

	public Canvas settingCanvas;
	public  Text soundMode;
	private static AudioSource settingsClip;
	public static bool isTutorialOpen =  false;
	
	// Use this for initialization
	void Start () 
	{
		settingsClip = gameObject.GetComponent<AudioSource> ();
		
		if (!isTutorialOpen) {
			settingCanvas.enabled = false;
			settingsClip.Stop ();
		} else {
		}

	}
	
	public void playSound()
	{
		settingsClip.Play ();
	}

	public void stopSound()
	{
		settingsClip.Stop ();
	}
	
	public void pausedTime()
	{
		Time.timeScale = 0;
	}
	
	public void resumeTimePause()
	{
		Time.timeScale = 1;
		settingCanvas.enabled = false;
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void toggleSound()
	{
		if (AudioListener.volume > 0) 
		{// sound off
			AudioListener.volume = 0;
			soundMode.text = "SOUND ON";
			soundMode.color = Color.yellow;
			
		} 
		else 
		{ //sound on
			AudioListener.volume = 1;
			soundMode.text = "SOUND OFF";
			soundMode.color = Color.white;
		}
	}
	
	public void openSettings()
	{
		settingCanvas.enabled = true;
		if (settingsClip != null) {
			settingsClip.Play ();
		}
	}
	
	public void closeSettings()
	{
		settingCanvas.enabled = false;
		if (settingsClip != null) {
			settingsClip.Stop ();
		}
	}
	
	public void howToPlayTut()
	{
		isTutorialOpen = true;
		Application.LoadLevel ("Tutorial");
	}

	public void loadLevel4()
	{
		Time.timeScale = 1;
		Application.LoadLevel ("level 1");
		Debug.Log ("level 4 loaded");
	}

	public void loadLevel5()
	{
		Application.LoadLevel (5);
	}

	public void loadLevel6()
	{
		Application.LoadLevel (6);
	}
}
