using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonDamage : MonoBehaviour {

	public float dmg = 5f;
	public float upForce, rightForce;


	// Originally OnCollisionEnter2D(Collision2D col)
	void OnTriggerEnter2D(Collider2D col){
		GameObject foe = col.gameObject;
		if(foe.GetComponentInChildren<BonHealth>()){
			BonHealth badHealth = foe.GetComponentInChildren<BonHealth>();
			badHealth.LoseHealth(dmg);
			if (foe.GetComponentInParent<Rigidbody2D>()){
				Rigidbody2D badrb2d = foe.GetComponentInParent<Rigidbody2D>();
				print ("contact");
				badrb2d.AddForce(new Vector2(rightForce, upForce), ForceMode2D.Force);
			}
		}
	}
}
