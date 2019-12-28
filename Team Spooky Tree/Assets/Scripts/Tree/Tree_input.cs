using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class Tree_input : MonoBehaviour
{

	public string player;
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
	Vector2 jumpHeight = new Vector2 (0, 10);


	private struct Controls
	{
		public string x, y, jump, attack;

		public Controls (string x_in, string y_in, string jump_in, string attack_in)
		{
			x = x_in;
			y = y_in;
			jump = jump_in;
			attack = attack_in;
		}
	}

	private Controls control;
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();

		leftMoving = false;
		rightMoving = false;
		jumping = false;
		crouching = false;
		if (player != "P2") {
			player = "P1";
		}
		control = new Controls ("Horiz" + player, "Vert" + player, "Jump" + player, "Fire1" + player);
	}

	void FixedUpdate ()
	{
		//float moveHorizontal = Input.GetAxis ("HorizP1");
		float moveHorizontal = Input.GetAxis (control.x);
	}
	// Update is called once per frame
	void Update ()
	{
		if (anim.GetBool ("dead")) {
			//if we are dead we shouldn't be able to do anything
			return;
		}
		if (Input.GetButtonDown (control.attack)) {
			anim.SetTrigger ("attack");
		}
		if (Input.GetAxis (control.y) < 0 && !jumping) {
			crouching = true;
			anim.SetBool ("crouch", true);
		} else {
			anim.SetBool ("crouch", false);
		}
		//Basically, if you're holding down one direction and you press another, you switch to moving in the new direction
		//if you release that new direction and you're still holding the old one, you should switch back
		if (Input.GetAxis (control.x) > 0 ) {
			leftMoving = false;
			rightMoving = true;
			anim.SetBool ("move_right", true);
			this.transform.position = new Vector3 (this.transform.position.x + move_step, this.transform.position.y);
		} else {
			anim.SetBool ("move_right", false);
			rightMoving = false;
		}
		
		if (Input.GetAxis (control.x) < 0) {
			leftMoving = true;
			rightMoving = false;
			anim.SetBool ("move_left", true);
			transform.position = new Vector3 (transform.position.x - move_step, transform.position.y);
		} else {
			leftMoving = false;
			anim.SetBool ("move_left", false);
		}

		if (Input.GetButtonDown(control.jump) && jumping == false) {
			jumping = true;
			anim.SetBool ("jump", true);
			rb2d.AddForce (jumpHeight, ForceMode2D.Impulse);
		}
		if (rb2d.velocity.y == 0) {
			jumping = false;
			anim.SetBool ("jump", false);
		}
	}
}
