using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapManager : MonoBehaviour {

    public Button[] buttons;
	// Use this for initialization
	void Start () {
	    for( int i = 0; i < buttons.Length; i++)
        {
            //Lock all Buttona except 1
        //    if (i != 1)
//                buttons[i].interactable = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
