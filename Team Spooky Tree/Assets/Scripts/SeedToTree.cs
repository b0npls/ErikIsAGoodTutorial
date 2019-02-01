using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedToTree : MonoBehaviour {

	private const float k_GroundRayLength = 0.2f;

	// add other random things it could spawn?

	public GameObject apple;

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}


	void FixedUpdate () {
		Grow();
	}

	void Grow () {
		Vector2 mySpot = new Vector2 (transform.position.x,transform.position.y-0.2f);

		// If on the ground...
        if (Physics2D.Raycast(mySpot, mySpot, k_GroundRayLength))
        {
			anim.SetTrigger("grounded");
        }
    }

    void RandomDirection () {
    	float randomX = Random.value * 10;
    	float randomY = Random.value * 10;
    	float isNegativeX = Random.value;
    	float isNegativeY = Random.value;
    	if (isNegativeX > 0.5){
    		randomX = randomX * -1;
    	}
    	if (isNegativeY > 0.8){
    		randomY = randomY * -1;
    	}
    	ThrowFruit (randomX, randomY);
    }

    void ThrowFruit (float xdirect, float ydirect) {
    	Vector3 offSet = new Vector3 (0, 1f, 0);
    	print (xdirect + " and " + ydirect);
    	GameObject fruit = Instantiate (apple) as GameObject;
    	fruit.transform.position = gameObject.transform.position + offSet;
    	fruit.GetComponent<Rigidbody2D>().velocity = new Vector2 (xdirect, ydirect);


    }

    // TODO add method that selfdestructs tree at end of animation rather than with time limit


}
