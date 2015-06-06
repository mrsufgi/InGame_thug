using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using UnityEngine.UI;

public class LockedCanvasEvent : MonoBehaviour {

    private static AudioSource settingsClip;
    Canvas UnlockCanvas;
    private Text LevelName;
    private Text LevelPrice;
    private Level m_Level;
    void Start()
    {
        //
        UnlockCanvas = gameObject.GetComponent<Canvas>();
        print(UnlockCanvas);
        settingsClip = gameObject.GetComponent<AudioSource>();
        LevelName = transform.FindChild("txt_LevelName").GetComponent<Text>();
        LevelPrice = transform.FindChild("txt_GasPoints").GetComponent<Text>();

        //
        LockedLevelHandler.OnOpenCanvas += this.OpenLockedCanvas;
    }

    void OnDestroy()
    {
        LockedLevelHandler.OnOpenCanvas -= this.OpenLockedCanvas;
    }

    public void OpenLockedCanvas(Level i_Level)
    {
        print(i_Level.ID);
        m_Level = i_Level;
        OpenLockedLevelCanvas();

        // set Gate unlock button

        // set price text

        // set level name
    }

    public void OpenLockedLevelCanvas()
    {
        UnlockCanvas.GetComponent<Canvas>().enabled = true;
        if (settingsClip != null)
        {
            settingsClip.Play();
        }
    }

    public void CloseLockedLevelCanvas()
    {
        UnlockCanvas.GetComponent<Canvas>().enabled = false;
        if (settingsClip != null)
        {
            settingsClip.Stop();
        }
    }

}
