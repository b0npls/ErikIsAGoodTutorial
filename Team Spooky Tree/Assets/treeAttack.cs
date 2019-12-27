using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collid)
	{
		Debug.Log ("inside tree's on trigger enter 2d");
		if (collid.gameObject.tag != gameObject.tag) {
			DamageTaker d = collid.GetComponentInParent<DamageTaker> ();
			Debug.Log("tree's attack is doing damage to : "+collid.name);
			if (d != null) {
				d.TakeDamage (1f, 50);
			} else {
				Debug.Log ("oops treeAttack's damagee is null");
			}
		}
	}
}
