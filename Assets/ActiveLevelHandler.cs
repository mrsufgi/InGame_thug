using UnityEngine;
using System.Collections;
using Soomla.Levelup;
using UnityEngine.UI;
using System;

public class ActiveLevelHandler : MonoBehaviour
{

    private Level m_ActiveLevel;
    private Button m_Button;
    private int m_Index;
    // Use this for initialization
    void Start()
    {
        m_Button = this.GetComponent<Button>();
        m_Button.onClick.AddListener(() => StartLevel());
    }

    void Update()
    {
       
    }
    public void StartLevel()
    {
        if (m_ActiveLevel.CanStart()) 
        {
            string level = "level" + (m_Index + 1) + "done";
            LevelManager.currentLevelIndex = m_Index + 1;
            LevelManager.CurrentLevel = m_ActiveLevel;
            Application.LoadLevel(level);
        }
    }

    public Level Level { get { return m_ActiveLevel; } set { m_ActiveLevel = value; } }
    public int Index { get { return m_Index; } set { m_Index = value; } }
}
