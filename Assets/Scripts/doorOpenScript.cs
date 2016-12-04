using UnityEngine;
using System.Collections;

public class doorOpenScript : MonoBehaviour {

	private Animator doorAnimator;
	public AudioClip doorAudio;
	GameObject keyManager = GameObject.Find("keyChain");

	// Use this for initialization
	void Start () 
	{
		doorAnimator = this.GetComponent<Animator> ();
		keyScript = keyManager.GetComponent<keyScript> ();

	
	}

	void onCollisionEnter (Collision col)
	{
		switch (col.gameObject.tag)
		{
		case "door1":
			if(keyScript.key1Collected == true)
			{
				doorAnimator.SetBool ("Open", true);
				AudioManager.instance.PlaySound (doorAudio);
			}
			break;

		case "door2":
			if (keyScript == true) 
			{
				doorAnimator.SetBool ("Open", true);
				AudioManager.instance.PlaySound (doorAudio);
			}
			break;

		case "door3":
			if (keyScript == true) 
			{
				doorAnimator.SetBool ("Open", true);
				AudioManager.instance.PlaySound (doorAudio);
			}
			break;

		case "door4":
			if (keyScript == true) 
			{
				doorAnimator.SetBool ("Open", true);
				AudioManager.instance.PlaySound (doorAudio);
			}
			break;

		
		}
	}
}
