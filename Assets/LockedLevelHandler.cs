using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using UnityEngine.UI;

public class LockedLevelHandler : MonoBehaviour {

    private Level m_LockedLevel;
    private Gate m_LevelGate;
    private Button m_Button;
    private int m_Index;
    private GUILevelSelectCreator PrefabHandler;
    private GameObject UnlockCanvas;
    private PurchasableGate m_PurGate;
    private double m_Price;

    public delegate void OpenAndSetCanvas(GameObject o_Self, Level o_Level, PurchasableGate o_Gate, int o_Index, double o_Price);
    public static event OpenAndSetCanvas OnOpenCanvas;
    void Start()
    {
        //    txt_LevelName = gameObject.GetComponentInChildren<Text>();
        UnlockCanvas = GameObject.FindWithTag("Panel_locked");
        //        print(UnlockCanvas);
        m_Button = this.GetComponent<Button>();

        if (m_LockedLevel != null)
        {
            m_LevelGate = m_LockedLevel.Gate;
            print(m_LevelGate);
        }
        PrefabHandler = GetComponentInParent<GUILevelSelectCreator>();
        m_Button.onClick.AddListener(() => OpenCanvas(m_LockedLevel));
    }


    public void OpenCanvas(Level i_Level)
    {

        GameObject PopupCanvas = UI_Manager_MainMenu.PopupCanvas;

        foreach (Transform child in PopupCanvas.transform)
        {

            bool active = true;
            if (child.name == "Panel_locked")
            {

                // true
            }
            else
            {
                active = false;
            }

            // enable only the setting panel.
            child.gameObject.SetActive(active);
        }

            PopupCanvas.gameObject.GetComponent<Canvas>().enabled = true;

            if (OnOpenCanvas != null)
        {
            OnOpenCanvas(gameObject, i_Level,m_PurGate ,m_Index, m_Price);
        }

       
            PopupCanvas.gameObject.GetComponent<Animator>().SetBool("isOpen", true);

            GameObject.FindWithTag("Panel_locked").GetComponent<Animator>().SetBool("isOpen", true);
            //      anim.SetBool("isOpen", true);

            //if (settingsClip != null)
            //{
            //    settingsClip.Play();
            //}
        
    }


    public Level LockedLevel
    {
        get
        {
            return m_LockedLevel;
        }
        set
        {
            m_LockedLevel = value;
        }
    }

    public int Index
    {
        get
        {
            return m_Index;
        }
        set
        {
            m_Index = value;
        }
    }

    public double Price { get
        {
            return m_Price;
        }
         set 
        {
            m_Price = value;
        }
    }

    public PurchasableGate PurchasableGate { get { return m_PurGate; } set { m_PurGate = value; }  }



    public void BuyGate()
    {

        if (m_PurGate.Open())
        {
          //  Util.LoadScene(3);
          //  StartCoroutine("WaitUntilOpen");
          //  print("niceeee");
            //  enabled = false;
            //  PrefabHandler.ActiveLevelEnbale(m_Index);


            // util with fade
            //Application.LoadLevel(level); // 3 SCENE 
            // NEED TO LOAD CERTAIN DATA FIRST>
            //   Util.LoadScene(3);
        }
    }
    void Awake()
    {
        LevelUpEvents.OnGateOpened += onGateOpened;

    }

    void OnDestroy()
    {
        LevelUpEvents.OnGateOpened -= onGateOpened;
    }


    public void onGateOpened(Gate gate)
    {
          if(gate == m_PurGate)
        {
            //   if (m_LevelGate.Open())
            //  {
            // string level = "level" + (m_Index + 1) + "done";
            //   LevelManager.currentLevelIndex = m_Index + 1;
            //      LevelManager.CurrentLevel = m_LockedLevel;
            //    Util.LoadScene(3);
            //  }
            StartCoroutine("WaitUntilOpen");
        } else
        {
           // print("bye");
        }
    }


    IEnumerator WaitUntilOpen()
    {
        while (!m_PurGate.IsOpen())
        {
            print("fuck");
        }
        yield return new WaitForSeconds(1.0f);
        if (m_LevelGate.Open())
        {
            string level = "level" + (m_Index + 1) + "done";
            LevelManager.currentLevelIndex = m_Index + 1;
            LevelManager.CurrentLevel = m_LockedLevel;
            Util.LoadScene(3);
        }
        Debug.Log("THE GATE IS NOW OPEN!!!!!");
    }
}
