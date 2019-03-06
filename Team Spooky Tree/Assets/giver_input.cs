using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giver_input : MonoBehaviour {

	//public float speed = 10f;

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
	Vector2 jumpHeight = new Vector2(0,10);

	public string player;

	private struct Controls {
		public string x, y, jump, attack;
		public Controls(string x_in, string y_in, string jump_in, string attack_in){
			x = x_in;
			y = y_in;
			jump = jump_in;
			attack = attack_in;
		}
	}
	private Controls control;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();

		leftMoving = false;
		rightMoving = false;
		jumping = false;
		crouching = false;

		//Default to P2 on nonacceptable input
		if (player != "P1") {
			player = "P2";
		}

		control = new Controls ("Horiz" + player, "Vert" + player, "Jump" + player, "Fire1" + player);
	}
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horiz" + player);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(control.attack)) {
			anim.SetTrigger ("attack");
		}
		if (Input.GetAxis (control.y) < 0 && !jumping) {
			anim.SetBool ("crouching", true);
		} else {
			anim.SetBool ("crouching", false);
		}
		
		if (Input.GetAxis (control.x) > 0) {
			leftMoving = false;
			rightMoving = true;
			anim.SetBool("move_right", true);
			this.transform.position = new Vector3(this.transform.position.x + move_step, this.transform.position.y);

		} else if (Input.GetAxis (control.x) < 0) {
			rightMoving = false;
			leftMoving = true;
			anim.SetBool("move_left", true);
			transform.position = new Vector3(transform.position.x - move_step, transform.position.y);
		}
		 else {
			leftMoving = false;
			rightMoving = false;
			anim.SetBool("move_right", false);
			anim.SetBool("move_left", false);
		}
		if ((Input.GetAxis(control.y) > 0 || Input.GetButtonDown(control.jump) ) && jumping == false) {
			jumping = true;
			anim.SetBool("jumping", true);
			rb2d.AddForce(jumpHeight, ForceMode2D.Impulse);
		}
		if (rb2d.velocity.y == 0) {
			jumping = false;
			anim.SetBool ("jumping", false);
		}
	}
}
