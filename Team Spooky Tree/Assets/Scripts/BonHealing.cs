using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonHealing : MonoBehaviour {

	public float healing = 2f;
	public float upForce, rightForce;
	public bool deathOnImpact = true;


	// Originally OnCollisionEnter2D(Collision2D col)
	void OnTriggerEnter2D(Collider2D col){
		GameObject foe = col.gameObject;
		if(foe.GetComponentInChildren<BonHealth>()){
			BonHealth badHealth = foe.GetComponentInChildren<BonHealth>();
			badHealth.GainHealth(healing);
			if (foe.GetComponentInParent<Rigidbody2D>()){
				Rigidbody2D badrb2d = foe.GetComponentInParent<Rigidbody2D>();
				print ("contact");
				badrb2d.AddForce(new Vector2(rightForce, upForce), ForceMode2D.Force);
				if (deathOnImpact){
					Destroy(gameObject,0.1f);
				}
			}
		}
	}
}
