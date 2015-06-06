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

    public delegate void OpenAndSetCanvas(Level o_Level);
    public static event OpenAndSetCanvas OnOpenCanvas;
    void Start()
    {
    //    txt_LevelName = gameObject.GetComponentInChildren<Text>();
        UnlockCanvas = GameObject.FindWithTag("LockedLevelPanel");
        print(UnlockCanvas);
        m_Button = this.GetComponent<Button>();
        m_LevelGate = m_LockedLevel.Gate;
        print(m_Button);
        PrefabHandler = GetComponentInParent<GUILevelSelectCreator>();
        m_Button.onClick.AddListener(() => OpenCanvas(m_LockedLevel));
    }

    void Update()
    {

    }


    public static void OpenCanvas(Level i_Level)
    {
        if (OnOpenCanvas != null)
        {
            OnOpenCanvas(i_Level);
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

    public void BuyGate()
    {
       PurchasableGate gate = Util.GetPurchasableGateInORList((GatesListOR)m_LevelGate);
       print(gate.ID);
      gate.Open();
        if (gate.Open()) 
      {
           enabled = false;
            PrefabHandler.ActiveLevelEnbale(m_Index);
           }
    }
}
