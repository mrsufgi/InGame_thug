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
        UnlockCanvas = GameObject.FindWithTag("LockedLevelPanel");
//        print(UnlockCanvas);
        m_Button = this.GetComponent<Button>();

        if (m_LockedLevel != null)
        {
            m_LevelGate = m_LockedLevel.Gate;
        }
        PrefabHandler = GetComponentInParent<GUILevelSelectCreator>();
        m_Button.onClick.AddListener(() => OpenCanvas(m_LockedLevel));
    }

    void Update()
    {

    }


    public  void OpenCanvas(Level i_Level)
    {
        if (OnOpenCanvas != null)
        {
            OnOpenCanvas(gameObject, i_Level,m_PurGate ,m_Index, m_Price);
        }
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



    public bool BuyGate()
    {
            if (m_LevelGate.Open()) 
          {
            enabled = false;
            PrefabHandler.ActiveLevelEnbale(m_Index);
                string level = "level" + (m_Index + 1) + "done";
                LevelManager.currentLevelIndex = m_Index + 1;
                LevelManager.CurrentLevel = m_LockedLevel;
                Application.LoadLevel(level);
            return true;
           } else
        {
            return false;
        }
    }
}
