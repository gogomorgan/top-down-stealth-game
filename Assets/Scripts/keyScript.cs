using UnityEngine;
using System.Collections;

public class keyScript : MonoBehaviour {
	public AudioClip keyAudio;
	public bool key1Collected = false;
	public bool key2Collected = false;
	public bool key3Collected = false;
	public bool key4Collected = false;
	public bool key5Collected = false;

	void onCollisionEnter (Collision col)
	{
		switch (col.gameObject.tag)
		{
		case "key1":
			
				AudioManager.instance.PlaySound (keyAudio);
				key1Collected = true;
			break;

		case "key2":

				AudioManager.instance.PlaySound (keyAudio);
				key2Collected = true;
			break;

		case "key3":

				AudioManager.instance.PlaySound (keyAudio);
				key3Collected = true;
			break;

		case "key4":
			
				AudioManager.instance.PlaySound (keyAudio);
				key4Collected = true;
			break;

		case "key5":
			
				AudioManager.instance.PlaySound (keyAudio);
				key5Collected = true;
			break;


		}
	}
}
