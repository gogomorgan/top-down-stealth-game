﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float sneakSpeed = 3; //Player sneaking speed;
    public float walkSpeed = 5; //Player walking speed; (This is Normal Speed)

    public KeyCode sneak; //Set Key to trigger Sneaking state. Can set in the inspector;

    [HideInInspector]public bool isSneak = false; //Is current movement in sneaking state;

    private float moveSpeed; //Move speed can be set to sneak speed or walk speed in the code;
    private Vector3 moveDirection; //Player's moveing direction;

    private Vector3 _mousePosition; //Mouse Cursor position in the screen;
    private Transform _trans; //Player transform;
    private CharacterController _playerController; //Character Controller that attached on Player;

    private Light spotLight;
    private float dimStep = 1.8f;
    private float rangeStep = 2.5f;
    private float angleStep = 5;

    private float lightMax = 3;
    private float lightMin = 1;
    private float rangeMax = 15;
    private float rangeMin = 6;
    private float angleMax = 105;
    private float angleMin = 75;

	// Use this for initialization
	void Start () {
        _trans = this.transform; //Get player's transform;
        _playerController = this.GetComponent<CharacterController>(); //Get player controller;

        moveDirection = Vector3.zero; //Initializing player's moving direction;

        spotLight = GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        //Start ------ Set player's light follows Mouse Cursor
        _mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        _trans.LookAt(_mousePosition + Vector3.up * _trans.position.y);
        //End -------- Set player's light follows Mouse Cursor


        //Start ------ Set player controller movement that controlled by keyboard
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKey(sneak)) { //If Sneak key is pressed and held, player can sneak in the scene;
            isSneak = true;
            moveDirection = _trans.TransformDirection(moveDirection);
            moveSpeed = sneakSpeed;
        }else{ //If Sneak key is released, player can back to normal walking state;
            isSneak = false;
            moveSpeed = walkSpeed;
        }

        _playerController.SimpleMove(moveDirection * moveSpeed);
        //End -------- Set player controller movement that controlled by keyboard

        ChangeLight();
    }

    private void ChangeLight() {
        if (GameData.playerSeeSpawner == true && GameData.spawnerSeePlayer == true) {
            spotLight.intensity = iTween.FloatUpdate(spotLight.intensity, lightMin, dimStep);
            spotLight.range = iTween.FloatUpdate(spotLight.range, rangeMin, rangeStep);
            spotLight.spotAngle = iTween.FloatUpdate(spotLight.spotAngle, angleMin, angleStep);
            GameData.canSpawnerChasePlayer = false;
            if (spotLight.intensity < 1.2f) {
                spotLight.color = Color.red;
                GameData.canSpawnerChasePlayer = true;
            }
            
        }else if(GameData.playerSeeSpawner == false){
            spotLight.intensity = iTween.FloatUpdate(spotLight.intensity, lightMax, dimStep);
            spotLight.range = iTween.FloatUpdate(spotLight.range, rangeMax, rangeStep);
            spotLight.spotAngle = iTween.FloatUpdate(spotLight.spotAngle, angleMax, angleStep);
            if (spotLight.intensity > 2.7f) {
                spotLight.color = new Color(0.91f, 1, 1);
            }
        }
    }
}
