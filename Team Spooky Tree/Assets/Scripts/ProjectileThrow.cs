using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrow : MonoBehaviour {

	Rigidbody2D rb;

	public Vector2 intVel = new Vector2 (1f,1f);

	void Start () {
		rb = GetComponent<Rigidbody2D>();

		rb.velocity = intVel;	
	}
	

	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col){
		Destroy (gameObject, 0.1f);
	}
}
