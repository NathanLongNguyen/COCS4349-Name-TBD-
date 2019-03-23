using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controls_2 : MonoBehaviour {

    private float inputDirection;
    private float jumpSpeed;
    private float speed = 10.0f;
    private float gravity = 1.0f;

    private Vector3 moveVector;
    private CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        inputDirection = Input.GetAxis("Horizontal") * speed;
        

        if (controller.isGrounded)
        {
            jumpSpeed = 0;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumpSpeed = 30;
            }
        }
        else
        {
            jumpSpeed -= gravity;
        }

        moveVector = new Vector3(inputDirection, jumpSpeed, 0);
        controller.Move(moveVector * Time.deltaTime);
	}
}
