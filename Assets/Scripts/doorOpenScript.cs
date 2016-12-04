using UnityEngine;
using System.Collections;

public class doorOpenScript : MonoBehaviour {

	private Animator doorAnimator;
	public AudioClip doorAudio;
	AudioSource audio;
	GameObject keyManager = GameObject.Find("keyChain");

	// Use this for initialization
	void Start () 
	{
		doorAnimator = this.GetComponent<Animator> ();
		keyScript = keyManager.GetComponent<keyScript> ();
		audio = GetComponent<AudioSource>();

	
	}

	void onCollisionEnter (Collision col)
	{
		switch (col.gameObject.tag)
		{
		case "door1":
			if(keyScript.key1Collected == true)
			{
				doorAnimator.SetBool ("Open", true);
				audio.PlayOneShot(doorAudio, 1f);
			}
			break;

		case "door2":
			if (keyScript == true) 
			{
				doorAnimator.SetBool ("Open", true);
				audio.PlayOneShot(doorAudio, 1f);
			}
			break;

		case "door3":
			if (keyScript == true) 
			{
				doorAnimator.SetBool ("Open", true);
				audio.PlayOneShot(doorAudio, 1f);
			}
			break;

		case "door4":
			if (keyScript == true) 
			{
				doorAnimator.SetBool ("Open", true);
				audio.PlayOneShot(doorAudio, 1f);
			}
			break;

		
		}
	}
}
