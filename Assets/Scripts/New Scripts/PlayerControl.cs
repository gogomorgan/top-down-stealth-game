using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float sneakSpeed = 3;
    public float walkSpeed = 5;

    public KeyCode sneak;

    private float moveSpeed;
    private Vector3 moveDirection;

    private Vector3 _mosePosition;
    private Transform _trans;
    private CharacterController _playerController;

	// Use this for initialization
	void Start () {
        _trans = this.transform;
        _playerController = this.GetComponent<CharacterController>();

        moveDirection = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        _mosePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        _trans.LookAt(_mosePosition + Vector3.up * _trans.position.y);

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKey(sneak)) {
            moveDirection = _trans.TransformDirection(moveDirection);
            moveSpeed = sneakSpeed;
        }else{
            moveSpeed = walkSpeed;
        }

        _playerController.SimpleMove(moveDirection * moveSpeed);
    }
}
