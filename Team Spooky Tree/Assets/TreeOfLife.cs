using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOfLife : MonoBehaviour {
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
        anim.ResetTrigger("attackButton");
        if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetTrigger("attackButton");
        }
        //Basically, if you're holding down one direction and you press another, you switch to moving in the new direction
        //if you release that new direction and you're still holding the old one, you should switch back
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            leftMoving = false;
            rightMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftMoving = true;
            rightMoving = false;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !leftMoving)
        {
            rightMoving = true;
            anim.SetBool("isWalkingForward", true);
            this.transform.position = new Vector3(this.transform.position.x + 0.05f, this.transform.position.y);
        } else
        {
            rightMoving = false;
            anim.SetBool("isWalkingForward", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !rightMoving)
        {
            leftMoving = true;
            anim.SetBool("isWalkingBackward", true);
            this.transform.position = new Vector3(this.transform.position.x - 0.05f, this.transform.position.y);
        }
        else
        {
            leftMoving = false;
            anim.SetBool("isWalkingBackward", false);
        }
    }
}
