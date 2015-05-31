using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Manager_MainMenu : MonoBehaviour {

	public  Canvas settingCanvas;
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
		settingsClip.Play ();



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

}
