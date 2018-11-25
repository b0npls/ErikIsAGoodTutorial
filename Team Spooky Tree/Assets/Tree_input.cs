﻿using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class Tree_input : MonoBehaviour {

	public float speed = 10f;

	private Rigidbody2D rb2d;

	bool rightMoving;
	bool leftMoving;
	bool jumping;
	bool crouching;
	
	Animator anim;
	
	const float floor_base = 0;
	const float fall_step = 1f;
	const float jump_step = 5f;
	const float move_step = 0.1f;
	Vector2 jumpHeight = new Vector2(0,30);
	
	private struct Controls {
		public KeyCode move_right, move_left, jump, attack, crouch;
		public Controls(KeyCode right, KeyCode left, KeyCode jump_in, KeyCode attack_in, KeyCode crouch_in){
		  move_right = right;
		  move_left = left;
		  jump = jump_in;
		  attack = attack_in;
		  crouch = crouch_in;
		}
	}
	Controls controls = new Controls(KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.RightControl, KeyCode.DownArrow);
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D> ();

		leftMoving = false ;
		rightMoving = false ;
		jumping = false ;
		crouching = false;
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("HorizP1");
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(controls.attack))
		{
			anim.SetTrigger("attack");
		}
		if (Input.GetKey(controls.crouch)) {
			//Debug.Log ("Crouching");
			crouching = true;
			anim.SetBool ("crouch", true);
		} else {
			//Debug.Log ("Not Crouching");
			anim.SetBool ("crouch", false);
		}
		//Basically, if you're holding down one direction and you press another, you switch to moving in the new direction
        //if you release that new direction and you're still holding the old one, you should switch back
        if (Input.GetKey(controls.move_right))
        {
            leftMoving = false;
            rightMoving = true;
        } 
		else {
		    rightMoving = false;
		}
		
        if (Input.GetKey(controls.move_left))
        {
            leftMoving = true;
            rightMoving = false;
        }
		else {
			leftMoving = false;
		}

        //if (Input.GetKey(KeyCode.RightArrow) && !leftMoving)
        if (rightMoving)
		{
            //rightMoving = true;
            anim.SetBool("move_right", true);
            this.transform.position = new Vector3(this.transform.position.x + move_step, this.transform.position.y);
        } else
        {
            //rightMoving = false;
            anim.SetBool("move_right", false);
        }

        //if (Input.GetKey(KeyCode.LeftArrow) && !rightMoving)
        if (leftMoving)
		{
            leftMoving = true;
            anim.SetBool("move_left", true);
            transform.position = new Vector3(transform.position.x - move_step, transform.position.y);
        }
        else
        {
            leftMoving = false;
            anim.SetBool("move_left", false);
        }
		//need to redo jumping
		if (Input.GetKey(controls.jump) && jumping == false) {
			jumping = true;
			anim.SetBool("jump", true);
			//transform.position = new Vector3(transform.position.x, transform.position.y + jump_step);
			rb2d.AddForce(jumpHeight, ForceMode2D.Impulse);

		}
/*		else {
			//anim.SetBool("jump", false);
			float y_temp = transform.position.y - fall_step;
			y_temp = Math.Max(floor_base,  y_temp);
			transform.position = new Vector3(transform.position.x, y_temp);
		}
		if (transform.position.y == floor_base) {
			//if we are on the ground we aren't jumping
			jumping = false;
			anim.SetBool("jump", false);
		}
		else {
			//if we aren't on the ground we are jumping
			jumping = true;
			anim.SetBool("jump", true);
		}*/	
	}
}
