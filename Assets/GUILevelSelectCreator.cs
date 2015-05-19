using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUILevelSelectCreator : MonoBehaviour {

    public GameObject openLevel;
    public GameObject lockedLevel;
    public int itemCount, columnCount;

    void Start()
    {
        int j = 0;
        for (int i = 0; i < itemCount; i++)
        {
            //this is used instead of a double for loop because itemCount may not fit perfectly into the rows/columns
            if (i % columnCount == 0)
                j++;


            //create a new item, name it, and set the parent
            GameObject newItem = Instantiate(openLevel) as GameObject;
            newItem.name = gameObject.name + " item at (" + i + "," + j + ")";
            newItem.transform.parent = gameObject.transform;
            newItem.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            newItem.GetComponentInChildren<Text>().text = i + "";
        }

    }
}
