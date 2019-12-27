using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giverAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collid) {
		//Debug.Log ("giverAttack - collid.gameObjectTag: " + collid.gameObject.tag + ", myTag: " + gameObject.tag);

		if (collid.gameObject.tag != gameObject.tag){
			//Debug.Log("giver's attack is doing damage to : "+collid.name);
			DamageTaker d = collid.GetComponentInChildren<DamageTaker> ();
			//Debug.Log ("giverAttack: is doing damage to - d " + d.ToString ());
			if (d != null) {
				d.TakeDamage (5f, 100);
			} else {
				Debug.Log ("Giver's damagee is null");
			}

		}
	}
}
