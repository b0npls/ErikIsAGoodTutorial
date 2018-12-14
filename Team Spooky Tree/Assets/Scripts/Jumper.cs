using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// I should consider renaming this like "physics script" or something. It actually handles all physcis
public class Jumper : MonoBehaviour {

	private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.

	[HideInInspector] public bool isJumping = false;
	private Rigidbody2D rb2d;
	private Animator anim;

	void Start () {
		rb2d = GetComponentInParent<Rigidbody2D>();
		anim = GetComponentInParent<Animator>();
	}
	

	void FixedUpdate (){
		Jump(isJumping);
		isJumping = false;
    }

	void Jump(bool jump){
    	//rb2d.AddForce(new Vector2(0f,jumpForce));
		Vector2 mySpot = new Vector2 (transform.position.x,transform.position.y-0.8f);

		// If on the ground and jump is pressed...
        if (Physics2D.Raycast(mySpot, mySpot, k_GroundRayLength) && jump)
        {
			anim.SetTrigger("jump");
			anim.SetBool("grounded", true);
        }
    }

    public void MakeJump(float jumpForce){
		// ... add force in upwards.
		rb2d.AddForce(Vector3.up*jumpForce, ForceMode2D.Force);
    }

	private void Oucherino(){
    	anim.SetTrigger("ouch");
    	//rb2d.AddForce(new Vector3 (-150f,-200f), ForceMode2D.Force);
    }
}
