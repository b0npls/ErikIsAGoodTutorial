using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeHealth : MonoBehaviour, DamageTaker {
	private float health;
	Animator anim;
	public void TakeDamage(float damage, int hitstun){
		health -= damage;
		//TODO do something with hitstun

		print ("Tree: Took d" + damage + " damage. Now  "+ health +" health.");
		if (health <= 0) {
			print ("Tree: oops my health is "+ health +" and I am dead");
			anim.SetBool ("dead", true);
		}

	}
		// Use this for initialization
	void Start () {
		anim = GetComponentInParent<Animator> ();
		anim.SetBool ("dead", false);
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
