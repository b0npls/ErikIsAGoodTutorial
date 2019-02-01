using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* So something to think about: It may make sense to use String variables for our inputs. This way the
characters can be both Player 1 and Player 2. If you're wondering how, we would use the Project Settings
Input and add new Axes that would be named the appropriate controls. When a player selects their character
that selection should cause the correct String Names to be put into the variables*/
// It should be noted I have not done this ^^^ yet in this version.

// Attack button plans: Q, E, R, F| Jump: W

public class BonMover : MonoBehaviour {

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
        anim = GetComponent<Animator>();
        jumpScr = GetComponentInChildren<Jumper>();
	}

	void Update () {
		timeSinceLastJump += Time.deltaTime;
		//anim.ResetTrigger("attack1");
		Attacks();
        
        //Basically, if you're holding down one direction and you press another, you switch to moving in the new direction
        //if you release that new direction and you're still holding the old one, you should switch back
		if (Input.GetKeyDown(KeyCode.D) && allowedToMove == true)
        {
            leftMoving = false;
            rightMoving = true;
        }
		if (Input.GetKeyDown(KeyCode.A) && allowedToMove == true)
        {
            leftMoving = true;
            rightMoving = false;
        }

		if (Input.GetKey(KeyCode.D) && !leftMoving && allowedToMove == true)
        {
            rightMoving = true;
            anim.SetBool("isWalkingForward", true);
            this.transform.position = new Vector3(this.transform.position.x + 0.05f, this.transform.position.y);
        } else
        {
            rightMoving = false;
            anim.SetBool("isWalkingForward", false);
        }

		if (Input.GetKey(KeyCode.A) && !rightMoving && allowedToMove == true)
        {
            leftMoving = true;
            anim.SetBool("isWalkingBackward", true);
            transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y);
        }
        else
        {
            leftMoving = false;
            anim.SetBool("isWalkingBackward", false);
        }

        if (Input.GetButtonDown(yMove)){
        	if (Input.GetAxis(yMove) > 0){
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
		if (Input.GetButtonDown(attack1))
        {
            anim.SetTrigger("attack1");
        }
		if (Input.GetButtonDown(attack2))
        {
            anim.SetTrigger("attack2");
        }
		if (Input.GetButtonDown(attack3))
        {
        	// Movement needs to be disabled during. Perhaps a bool to set false?
            anim.SetTrigger("attack3");
        }
		if (Input.GetButtonDown(attack4))
        {
            anim.SetTrigger("attack4");
        }
		
    }

    public void Jumperino(){
    	jumpScr.MakeJump(jumpForce);
    }

 }
