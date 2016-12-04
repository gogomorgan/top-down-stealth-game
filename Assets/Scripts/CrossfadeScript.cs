﻿using UnityEngine;
using System.Collections;

public class CrossfadeScript : MonoBehaviour
{
	public static CrossfadeScript Instance;
	
	void Awake ()
	{
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonCrossfade(AudioClip newTrack)
	{
		Crossfade(newTrack);
	}

	public static void Crossfade(AudioClip newTrack)
	{
		Instance.StopAllCoroutines();
		
		if(Instance.GetComponents<AudioSource>().Length > 1)
		{
			Destroy(Instance.GetComponent<AudioSource>());
		}
		
		AudioSource newAudioSource = Instance.gameObject.AddComponent<AudioSource>();
		
		newAudioSource.volume = 0.0f;
		
		newAudioSource.clip = newTrack;
		
		newAudioSource.Play();
		
		Instance.StartCoroutine(Instance.ActuallyCrossfade(newAudioSource,1.0f));
	}

	public static void Crossfade(AudioClip newTrack, float fadeTime)
	{
		Instance.StopAllCoroutines();

		if(Instance.GetComponents<AudioSource>().Length > 1)
		{
			Destroy(Instance.GetComponent<AudioSource>());
		}

		AudioSource newAudioSource = Instance.gameObject.AddComponent<AudioSource>();

		newAudioSource.volume = 0.0f;

		newAudioSource.clip = newTrack;

		newAudioSource.Play();

		Instance.StartCoroutine(Instance.ActuallyCrossfade(newAudioSource,fadeTime));
	}

	IEnumerator ActuallyCrossfade(AudioSource newSource, float fadeTime)
	{
		float t = 0.0f;

		float initialVolume = GetComponent<AudioSource>().volume;

		while(t < fadeTime)
		{
			GetComponent<AudioSource>().volume = Mathf.Lerp(initialVolume,0.0f,t/fadeTime);
			newSource.volume = Mathf.Lerp(0.0f,1.0f,t/fadeTime);

			t += Time.deltaTime;
			yield return null;
		}

		newSource.volume = 1.0f;

		Destroy(GetComponent<AudioSource>());
	}


}
