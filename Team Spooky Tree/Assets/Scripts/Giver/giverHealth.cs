using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giverHealth : MonoBehaviour, DamageTaker {
	private float health;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponentInParent<Animator> ();
		anim.SetBool ("dead", false);
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void TakeDamage(float damage, int hitstun){
		health -= damage;
		//TODO do something with hitstun

		print ("giver: Took " + damage + " damage. Now  "+ health +" health.");
		if (health <= 0) {
			print ("giver: oops my health is "+ health +" and I am dead");
			anim.SetBool ("dead", true);
		}
	}
}
