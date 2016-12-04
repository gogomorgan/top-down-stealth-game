using UnityEngine;
using System.Collections;

public class keyScript : MonoBehaviour {
	public AudioClip keyAudio;
	AudioSource audio;
	public bool key1Collected = false;
	public bool key2Collected = false;
	public bool key3Collected = false;
	public bool key4Collected = false;
	public bool key5Collected = false;


	void Start ()
	{
		audio = GetComponent<AudioSource>();
	}

	void onCollisionEnter (Collision col)
	{
		switch (col.gameObject.tag)
		{
		case "key1":
			
			audio.PlayOneShot(keyAudio, 1f);
				key1Collected = true;
			break;

		case "key2":

			audio.PlayOneShot(keyAudio, 1f);
				key2Collected = true;
			break;

		case "key3":

			audio.PlayOneShot(keyAudio, 1f);
				key3Collected = true;
			break;

		case "key4":
			
			audio.PlayOneShot(keyAudio, 1f);
				key4Collected = true;
			break;

		case "key5":
			
			audio.PlayOneShot(keyAudio, 1f);
				key5Collected = true;
			break;


		}
	}
}
