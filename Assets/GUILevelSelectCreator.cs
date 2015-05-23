using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Levelup;
using System.Collections.Generic;
using System.Linq;
using Soomla.Store;

public class GUILevelSelectCreator : MonoBehaviour {

    public GameObject OpenLevel;
    public GameObject LockedLevel;
    private int levelCount, columnCount = 3;
    World m_currentWorld;

    void Start()
    {
        m_currentWorld = SoomlaLevelUp.GetWorld("blueWorld_ID");
  
        //   levelCount = SoomlaLevelUp.GetLevelCountInWorld(m_currentWorld);
        //int j = 0;
        //for (int i = 0; i < levelCount; i++)
        //{
        //    //this is used instead of a double for loop because itemCount may not fit perfectly into the rows/columns
        //    if (i % columnCount == 0)
        //        j++;
        int j = 0;
        GameObject newItem = null;
        Level currentInstantiatedLevel = null;
        for (int i = 0; i < m_currentWorld.InnerWorldsMap.Count; i++)
        {


            if (i % columnCount == 0)
            {
                j++;
            }
            currentInstantiatedLevel = (Level)m_currentWorld.GetInnerWorldAt(i);

            //  print(currentInstantiatedLevel.Scores.Values.ElementAt<Score>(1).ID);

            //create a new item, name it, and set the parent
            bool v_LockedLevelFlag = true;
            LockedLevelHandler lockedLevelHandler = null;
            if (i > 0)
            {
             //   currentInstantiatedLevel.Gate.Open();
            }
            if (currentInstantiatedLevel.CanStart())

            {
                v_LockedLevelFlag = false;
                newItem = Instantiate(OpenLevel) as GameObject;
            }
            else
            {
                v_LockedLevelFlag = true;
                newItem = Instantiate(LockedLevel) as GameObject;
                lockedLevelHandler = newItem.GetComponent<LockedLevelHandler>();
                lockedLevelHandler.LockedLevel = currentInstantiatedLevel;

            }

            newItem.name = gameObject.name + " item at (" + i + "," + j + ")";
            newItem.transform.parent = gameObject.transform;
            newItem.transform.localScale = new Vector3(0.9f, 0.9f, 1);

            if (!v_LockedLevelFlag)
            {
                newItem.GetComponentInChildren<Text>().text = i + 1 + "";
            } else
            {
                PurchasableGate pg = Util.GetPurchasableGateInORList((GatesListOR) currentInstantiatedLevel.Gate);
                double price =  Util.GetVirtualItemPriceByID(pg.AssociatedItemId);
                newItem.GetComponentInChildren<Text>().text = price + "";
            }

            // Handle stars (active
            StarsHandler[] sh = newItem.GetComponentsInChildren<StarsHandler>();
            if(sh.Length < 3)
            {
                Debug.Log("Level must have 3 point missions");
                continue;
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

}
