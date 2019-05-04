using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* So something to think about: It may make sense to use String variables for our inputs. This way the
characters can be both Player 1 and Player 2. If you're wondering how, we would use the Project Settings
Input and add new Axes that would be named the appropriate controls. When a player selects their character
that selection should cause the correct String Names to be put into the variables*/
// It should be noted I have not done this ^^^ yet in this version.

// Attack button plans: Q, E, R, F| Jump: W

public class BonMover : Fighter {
	public string xMove, yMove, attack1, attack2, attack3, attack4;
	public float jumpForce = 100f;

	private bool rightMoving = false;
	private bool leftMoving = false;
	private bool allowedToMove = true;	// Bool to set false during some attacks
	private float jumpDelay = 0.5f;
	private float timeSinceLastJump;
    private Animator anim;
    private Jumper jumpScr;
	
	void Start () {
        xMove = "Horiz" + player;
        yMove = "Vert" + player;
        attack1 = "Fire1" + player;
        attack2 = "Fire2" + player;
        attack3 = "Fire3" + player;
        attack4 = "Fire4" + player;
        anim = GetComponent<Animator>();
        jumpScr = GetComponentInChildren<Jumper>();
	}

	void Update () {
		timeSinceLastJump += Time.deltaTime;
		//anim.ResetTrigger("attack1");
		Attacks();
        


        if (Input.GetAxis("Horiz" + player) > 0)
        {
            anim.SetBool("isWalkingForward", true);
            anim.SetBool("isWalkingBackward", false);
            this.transform.position = new Vector3(this.transform.position.x + 0.05f, this.transform.position.y);
        } else if (Input.GetAxis("Horiz" + player) < 0)
        {
            anim.SetBool("isWalkingForward", false);
            anim.SetBool("isWalkingBackward", true);
            transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y);
        } else
        {
            anim.SetBool("isWalkingForward", false);
            anim.SetBool("isWalkingBackward", false);
        }

        if (Input.GetButtonDown("Vert" + player)){
        	if (Input.GetAxis("Vert" + player) > 0){
        		if (timeSinceLastJump > jumpDelay){
        			jumpScr.isJumping = true;
        			timeSinceLastJump = 0f;
        		}
        	}
        }
    }

  

    public void StayStill (){
		allowedToMove = false;
    }

    public void MoveWhenever () {
		allowedToMove = true;
    }

    void Attacks (){
		anim.ResetTrigger("attack1");
		anim.ResetTrigger("attack2");
		anim.ResetTrigger("attack3");
		anim.ResetTrigger("attack4");
		if (Input.GetButtonDown("Fire1" + player))
        {
            anim.SetTrigger("attack1");
        }
		if (Input.GetButtonDown("Fire2" + player))
        {
            anim.SetTrigger("attack2");
        }
		if (Input.GetButtonDown("Fire3" + player))
        {
        	// Movement needs to be disabled during. Perhaps a bool to set false?
            anim.SetTrigger("attack3");
        }
		if (Input.GetButtonDown("Fire4" + player))
        {
            anim.SetTrigger("attack4");
        }
		
    }

    public void Jumperino(){
    	jumpScr.MakeJump(jumpForce);
    }

 }
