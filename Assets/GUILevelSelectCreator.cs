using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Levelup;
using System.Collections.Generic;
using System.Linq;
using Soomla.Store;
using System;

public class GUILevelSelectCreator : MonoBehaviour {

    //    public GameObject OpenLevel;
    //   public GameObject LockedLevel;
    public GameObject m_LevelSelect;
    private int levelCount, columnCount = 3;
    World m_currentWorld;
    GameObject newItem = null;
    List<GameObject> m_Levels;

    Level currentInstantiatedLevel = null;
    void Start()
    {
        m_currentWorld = SoomlaLevelUp.GetWorld("blueWorld_ID");
        m_Levels = new List<GameObject>();
        //   levelCount = SoomlaLevelUp.GetLevelCountInWorld(m_currentWorld);
        //int j = 0;
        //for (int i = 0; i < levelCount; i++)
        //{
        //    //this is used instead of a double for loop because itemCount may not fit perfectly into the rows/columns
        //    if (i % columnCount == 0)
        //        j++;
        int j = 0;


        for (int i = 0; i < m_currentWorld.InnerWorldsMap.Count; i++)
        {


            if (i % columnCount == 0)
            {
                j++;
            }
            currentInstantiatedLevel = (Level)m_currentWorld.GetInnerWorldAt(i);
            print(currentInstantiatedLevel.ID);

            //  print(currentInstantiatedLevel.Scores.Values.ElementAt<Score>(1).ID);

            //create a new item, name it, and set the parent
            bool v_LockedLevelFlag = true;

            v_LockedLevelFlag = (currentInstantiatedLevel.CanStart()) ? true : false;
            print(v_LockedLevelFlag);

            // NEW BUTTON - ADD TO LEVEL ARRAY
            GameObject LevelSelectObject = Instantiate(m_LevelSelect) as GameObject;
            m_Levels.Add(LevelSelectObject);


            LevelSelectObject.name = gameObject.name + " item at (" + i + "," + j + ")";
            LevelSelectObject.transform.parent = gameObject.transform;
            LevelSelectObject.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            LockedLevelHandler lockedLevelHandler = null;

            print(LevelSelectObject.name);
            if (v_LockedLevelFlag)

            {
                ActiveLevelEnbale(i);
            }
            else
            {
                LockedLevelEnable(i);
            }
        }
    }

    public void LockedLevelEnable(int index)
    {
        GameObject LevelSelectObject = m_Levels[index];
        newItem = LevelSelectObject.transform.GetChild(1).gameObject;
        newItem.SetActive(true);
        print(newItem.name);
        LevelSelectObject.transform.GetChild(0).gameObject.SetActive(false);
        //LockedLevelHandler lockedLevelHandler = newItem.GetComponent<LockedLevelHandler>();
        //lockedLevelHandler.LockedLevel = currentInstantiatedLevel;
        //lockedLevelHandler.Index = index;
        //PurchasableGate pg = Util.GetPurchasableGateInORList((GatesListOR)currentInstantiatedLevel.Gate);
        //double price = Util.GetVirtualItemPriceByID(pg.AssociatedItemId);
        //newItem.GetComponentInChildren<Text>().text = price + "";
      
    }

    public void ActiveLevelEnbale(int index)
    {
        GameObject LevelSelectObject = m_Levels[index];
        print(LevelSelectObject.name);
        newItem = LevelSelectObject.transform.GetChild(0).gameObject;
        newItem.SetActive(true);
        newItem.GetComponentInChildren<Text>().text = index + 1 + "";
        LevelSelectObject.transform.GetChild(1).gameObject.SetActive(false);
     //   starCalculator();
    }

    private void starCalculator()
    {
        // Handle stars (active
        StarsHandler[] sh = newItem.GetComponentsInChildren<StarsHandler>();
        if (sh.Length < 3)
        {
            Debug.Log("Level must have 3 point missions");
        }
        for (int k = 0; k < 3; k++)
        {

            //    Mission misson = currentInstantiatedLevel.Missions[k];
            //    if (k <= 0)
            //    {
            //    //misson.IsAvailable();
            //    print(currentInstantiatedLevel.GetSingleScore().ID);

            //}
            Score starRank = currentInstantiatedLevel.Scores.Values.ElementAt<Score>(1);

            if (starRank.HasRecordReached(k + 1))
            {
                sh[k].SetActiveStarSprite(true);
            }
            else
            {
                sh[k].SetActiveStarSprite(false);
            }
        }
    }
}
