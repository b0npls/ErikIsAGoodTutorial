using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour, DamageTaker {
	private float health;

	public void TakeDamage(float damage, int hitstun){
		health -= damage;
		//TODO do something with hitstun

		print ("Tree: Took -" + damage + "- damage. Now  "+ health +" health.");
		if (health <= 0) {
			print ("Tree: oops my health is "+ health +" and I am dead");
		}

	}
		// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
