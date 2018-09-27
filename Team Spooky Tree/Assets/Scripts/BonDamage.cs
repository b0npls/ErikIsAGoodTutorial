using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonDamage : MonoBehaviour {

	public float dmg = 5f;


	// Originally OnCollisionEnter2D(Collision2D col)
	void OnTriggerEnter2D(Collider2D col){
		GameObject foe = col.gameObject;
		if(foe.GetComponentInChildren<BonHealth>()){
			BonHealth badHealth = foe.GetComponentInChildren<BonHealth>();
			if (foe.tag != "AttackP1"){
				badHealth.LoseHealth(dmg);
			}
		}
	}
}
