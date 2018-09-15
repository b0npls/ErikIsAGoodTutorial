using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class Tree_input : MonoBehaviour {
	bool rightMoving;
	bool leftMoving;
	bool jumping;
	
	Animator anim;
	
	const float floor_base = 0;
	const float fall_step = 0.08f;
	const float jump_step = 0.1f;
	const float move_step = 0.1f;
	
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
	Controls controls = new Controls(KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.RightControl, KeyCode.RightShift);
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		leftMoving = false ;
		rightMoving = false ;
		jumping = false ;
	}
	
	// Update is called once per frame
	void Update () {
		anim.ResetTrigger("attackButton");
		if (Input.GetKeyDown(controls.attack))
		{
			anim.SetTrigger("attackButton");
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
		
		if (Input.GetKey(controls.jump)) {
			jumping = true;
			anim.SetBool("jump", true);
			transform.position = new Vector3(transform.position.x, transform.position.y + jump_step);
		}
		else {
			jumping = false;
			anim.SetBool("jump", false);
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
		}	
	}
}
