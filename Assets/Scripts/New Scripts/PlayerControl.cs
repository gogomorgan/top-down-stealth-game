using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float sneakSpeed = 3;
    public float walkSpeed = 5;
    public float runSpeed = 10;

    public KeyCode sneak;
    public KeyCode run;

    private float moveSpeed;

    private Vector3 _mosePosition;
    private Transform _trans;
    private CharacterController _playerController;

	// Use this for initialization
	void Start () {
        _trans = this.transform;
        _playerController = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        _mosePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        _trans.LookAt(_mosePosition + Vector3.up * _trans.position.y);

        if (Input.GetKey(sneak)) {
            Debug.Log("sneak");
            moveSpeed = sneakSpeed;
        } else if (Input.GetKey(run)) {
            Debug.Log("run");
            moveSpeed = runSpeed;
        }else{
            moveSpeed = walkSpeed;
        }

        _playerController.SimpleMove(new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, Input.GetAxis("Vertical") * moveSpeed));
    }
}
