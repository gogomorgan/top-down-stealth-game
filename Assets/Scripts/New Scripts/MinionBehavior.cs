using UnityEngine;
using System.Collections;

public class MinionBehavior : MonoBehaviour {
    private NavMeshAgent _navAgent;
    private Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player").transform;
        _navAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate() {
        _navAgent.SetDestination(target.position);
    }
}
