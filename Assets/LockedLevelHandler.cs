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

    void Start()
    {
    //    m_LevelGate = m_LockedLevel.Gate;
//        print(m_LevelGate.ID);
        m_Button = this.GetComponent<Button>();
        print(m_Button);
        PrefabHandler = GetComponentInParent<GUILevelSelectCreator>();
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
      //  gate.Open();
        if (gate.Open()) 
        {
            enabled = false;
            PrefabHandler.ActiveLevelEnbale(m_Index);
        }
    }
}
