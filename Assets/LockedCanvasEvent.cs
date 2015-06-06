using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using UnityEngine.UI;
using Soomla.Store;

public class LockedCanvasEvent : MonoBehaviour {

    private static AudioSource settingsClip;
    Canvas UnlockCanvas;
    private Text LevelName;
    private Text LevelPrice;
    private Level m_Level;
    private Button m_UnlockButton;
    private PurchasableGate m_Gate;
    private GameObject m_Triggered;
    void Start()
    {

        //
        UnlockCanvas = gameObject.GetComponent<Canvas>();
        print(UnlockCanvas);
        settingsClip = gameObject.GetComponent<AudioSource>();
        LevelName = transform.Find("Locked_Panel/Level Name/txt_levelName").gameObject.GetComponent<Text>();
        LevelPrice = transform.Find("Locked_Panel/GasCoinsPanel/txt_GasPoints").gameObject.GetComponent<Text>();
        m_UnlockButton = transform.Find("Locked_Panel/btn_Unlock").gameObject.GetComponent<Button>();

//        print(LevelName.text);


    }
    
    void Awake()
    {
        //
        LockedLevelHandler.OnOpenCanvas += this.OpenLockedCanvas;

    }

    void OnDestroy()
    {
        LockedLevelHandler.OnOpenCanvas -= this.OpenLockedCanvas;
    }

    public void OpenLockedCanvas(GameObject i_Trigger, Level i_Level, PurchasableGate i_Gate ,int i_Index, double i_Price)
    {
        m_Level = i_Level;
        OpenLockedLevelCanvas();
        m_Triggered = i_Trigger;
        // set Gate unlock button
        m_Gate = i_Gate;

        // disable button when u 
        if (StoreInventory.GetItemBalance("coin_currency_ID") < i_Price)
        {
            m_UnlockButton.enabled = false;
        }

        // set price text
            LevelPrice.text = i_Price + "";
        // set level name
        LevelName.text = string.Format("Level {0}", i_Index + 1);

        //
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

    public void BuyGate()
    {
        LockedLevelHandler l = m_Triggered.GetComponent<LockedLevelHandler>();
        if (l.BuyGate())
        {
            gameObject.GetComponent<Canvas>().enabled = false;
        }

    }


}
