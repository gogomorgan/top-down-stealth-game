using UnityEngine;
using System.Collections;

public class SpawnerBehavior : MonoBehaviour {
	public float idleSpeed = 5;
	public bool isPathReversed = false;
	public string SpawnerPath = null;

	private Transform _trans;

	// Use this for initialization
	void Start () {
		_trans = this.transform;
		if (SpawnerPath != null) {
			moveOnPath ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void moveOnPath(){
		iTween.MoveTo (_trans.gameObject, iTween.Hash ("path", iTweenPath.GetPath (SpawnerPath),"orienttopath", true, "speed", idleSpeed, "easetype", iTween.EaseType.linear, "oncomplete", "moveBackOnPath"));
	}

	private void moveBackOnPath(){
		if (isPathReversed == true) {
			iTween.MoveTo (_trans.gameObject, iTween.Hash ("path", iTweenPath.GetPathReversed (SpawnerPath), "orienttopath", true, "speed", idleSpeed, "easetype", iTween.EaseType.linear, "oncomplete", "moveOnPath"));
		} else {
			moveOnPath ();
		}
	}
}
