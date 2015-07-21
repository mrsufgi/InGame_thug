using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Manager_MainMenu : MonoBehaviour
{

    public static CanvasGroup canvasGroup;
    public static GameObject PopupCanvas;
    public GameObject shopCanvas;
    public GameObject unlockCanvas;
    public Text soundMode;
    private static AudioSource settingsClip;
    public static bool isTutorialOpen = false;

    // Use this for initialization
    void Awake()
    {
        canvasGroup = GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<CanvasGroup>();
        PopupCanvas = GameObject.FindGameObjectWithTag("PopupCanvas");
        settingsClip = gameObject.GetComponent<AudioSource>();

        if (!isTutorialOpen)
        {
            PopupCanvas.gameObject.GetComponent<Canvas>().enabled = false;
            settingsClip.Stop();
        }
        else
        {
            PopupCanvas.gameObject.GetComponent<Canvas>().enabled = false;
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
        PopupCanvas.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

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

    public void openShop(Animator anim)
    {
        foreach (Transform child in PopupCanvas.transform)
        {
            // PopupCanvas.transform.FindChild("Panel_settings").gameObject.SetActive(true);
            bool active = true;
            if (child.name == "Panel_shop")
            {

                // true
            }
            else
            {
                active = false;
            }
            child.gameObject.SetActive(active);
        }

        anim.SetBool("isOpen", true);
        PopupCanvas.gameObject.GetComponent<Canvas>().enabled = true;
        if (settingsClip != null)
        {
            settingsClip.Play();
        }
    }

    public void openSettings(Animator anim)
    {
        foreach (Transform child in PopupCanvas.transform)
        {
            // PopupCanvas.transform.FindChild("Panel_settings").gameObject.SetActive(true);
            bool active = true;
            if(child.name == "Panel_settings")
            {

                // true
            } else
            {
                active = false;  
            }
            child.gameObject.SetActive(active);
        }

        anim.SetBool("isOpen", true);
        PopupCanvas.gameObject.GetComponent<Canvas>().enabled = true;
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
        Application.LoadLevel("Tutorial");
    }


    public void loadLevelOne()
    {
        Application.LoadLevel(3);
        Debug.Log("level load");
    }
}
