using UnityEngine;
using System.Collections;

public class playSounds : MonoBehaviour {
	public AudioClip coins_Clip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playCoinSound()
	{
        
            AudioSource.PlayClipAtPoint (coins_Clip, transform.position);

        

	}
}
