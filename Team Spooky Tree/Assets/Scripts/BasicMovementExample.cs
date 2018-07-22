using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementExample : MonoBehaviour {

	public float speed = 10f; //this can be changed in the inspector; you can leave it alone here for now.

	private Rigidbody2D	rb2d;
	
	// Use this for initialization (this is a default comment)
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame (this is a default comment)
	void Update () {
		
	}

	// FixedUpdate is called once per physics iirc
	void FixedUpdate (){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb2d.AddForce (movement*speed);
	}
}
