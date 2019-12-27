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
		//Debug.Log ("treeAttack - collid: " + collid.ToString());
		//Debug.Log ("treeAttack - collid.gameObjectTag: " + collid.gameObject.tag + ", myTag: " + gameObject.tag);
		if (collid.gameObject.tag != gameObject.tag) {
			DamageTaker d = collid.GetComponentInChildren<DamageTaker> ();
			//Debug.Log("tree's attack is doing damage to : "+d.ToString());

			if (d != null) {
				d.TakeDamage (5f, 50);
			} else {
				Debug.Log ("oops treeAttack's damagee is null");
			}
		}
	}
}
