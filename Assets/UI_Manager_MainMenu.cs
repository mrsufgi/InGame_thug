﻿    using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Manager_MainMenu : MonoBehaviour {

    public static GameObject settingCanvas;
    public GameObject shopCanvas;
    public GameObject unlockCanvas;
    public Text soundMode;
    private static AudioSource settingsClip;
    public static bool isTutorialOpen = false;

    // Use this for initialization
    void Awake()
    {
        settingCanvas = GameObject.FindGameObjectWithTag("Settings");
        settingsClip = gameObject.GetComponent<AudioSource>();

        if (!isTutorialOpen) {
            settingCanvas.gameObject.GetComponent<Canvas>().enabled = false;
            settingsClip.Stop();
        } else {
            settingCanvas.gameObject.GetComponent<Canvas>().enabled = false;
        }
        settingsClip.Play();
    }



    public void pausedTime()
    {
        Time.timeScale = 0;
    }

    public void resumeTimePause()
    {
        Time.timeScale = 1;
        settingCanvas.SetActive(false);
    }


    // Update is called once per frame
    void Update() {

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

    public void openSettings(Animator anim)
    {
        anim.SetBool("isOpen", true);
            settingCanvas.gameObject.GetComponent<Canvas>().enabled = true;
            if (settingsClip != null)
            {
                settingsClip.Play();
            }
        }



    public void closeSettings(Animator anim)
    {

        Debug.Log("close load");
        anim.SetBool("isOpen", false);      
    }



public void openShop()
    {
        shopCanvas.gameObject.SetActive(true);
        //shopCanvas.gameObject.GetComponent<Canvas>().enabled = true;
        /*if (settingsClip != null)
        {
            settingsClip.Play();
        }*/
    }

    public void closeShop()
    {
        Debug.Log("close load");
        shopCanvas.gameObject.SetActive(false);
        //shopCanvas.gameObject.GetComponent<Canvas>().enabled = false;
        /*if (settingsClip != null)
        {
            settingsClip.Stop();
        }*/
    }

    public void closeUnlockedCanvas()
    {
        Debug.Log("close load");
        unlockCanvas.gameObject.GetComponent<Canvas>().enabled = false;
        if (settingsClip != null)
        {
            settingsClip.Stop();
        }
    }


    public void howToPlayTut()
	{
		isTutorialOpen = true;
		Application.LoadLevel ("Tutorial");
	}


	public void loadLevelOne()
	{
		Application.LoadLevel (3);
		Debug.Log ("level load");
	}
}
