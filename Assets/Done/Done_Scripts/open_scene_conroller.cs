using UnityEngine;
using System.Collections;

public class open_scene_conroller : MonoBehaviour
{
	bool isSoundOn = true;

	void Start ()
	{

		
	}
	

	public void play()
	{
		Application.LoadLevel (1);
	}

	public void soundOnOff(){
		if (isSoundOn) {
			AudioListener.volume=0;
			isSoundOn=false;
		} else {
			AudioListener.volume=1;
			isSoundOn=true;
		}
	}

}