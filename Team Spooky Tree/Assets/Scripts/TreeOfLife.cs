using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOfLife : Fighter, DamageTaker {
    bool rightMoving;
    bool leftMoving;

    Animator anim;
	// Use this for initialization
	void Start () {
        
        anim = GetComponent<Animator>();
        leftMoving = false;
        rightMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
        int hstun = anim.GetInteger("hitstun");
        if (hstun > 0) { anim.SetInteger("hitstun", hstun - 1); }
        anim.ResetTrigger("attackButton");
        if (Input.GetButtonDown("Fire1" + player))
        {
            anim.SetTrigger("attackButton");
        }
        //Basically, if you're holding down one direction and you press another, you switch to moving in the new direction
        //if you release that new direction and you're still holding the old one, you should switch back
        if(Input.GetAxis("Horiz"+player) > 0)
        {
            anim.SetBool("isWalkingForward", true);
            anim.SetBool("isWalkingBackward", false);
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y);
        }
        else if(Input.GetAxis("Horiz"+player) < 0)
        {
            anim.SetBool("isWalkingForward", false);
            anim.SetBool("isWalkingBackward", true);

        }
        else
        {
            anim.SetBool("isWalkingForward", false);
            anim.SetBool("isWalkingBackward", false);
        }
        //if (Input.GetKey(KeyCode.RightArrow) && !leftMoving)
        //{
        //    rightMoving = true;
        //    anim.SetBool("isWalkingForward", true);
        //    this.transform.position = new Vector3(this.transform.position.x + 0.05f, this.transform.position.y);
        //} else
        //{
        //    rightMoving = false;
        //    anim.SetBool("isWalkingForward", false);
        //}

        //if (Input.GetKey(KeyCode.LeftArrow) && !rightMoving)
        //{
        //    leftMoving = true;
        //    anim.SetBool("isWalkingBackward", true);
        //    transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y);
        //}
        //else
        //{
        //    leftMoving = false;
        //    anim.SetBool("isWalkingBackward", false);
        //}
    }

    public void TakeDamage(float damage, int hitstun)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetInteger("hitstun", hitstun);
        health -= damage;
    }
    public void Move(float amount)
    {
        transform.position = new Vector3(transform.position.x + amount, transform.position.y);
    }
}
