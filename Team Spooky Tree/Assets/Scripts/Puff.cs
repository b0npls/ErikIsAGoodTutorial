using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puff : MonoBehaviour {
    int dirMult = 0;
    public void SetDirection(bool dir)
    {
        dirMult = dir ? -1 : 1;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        transform.position = new Vector3(this.transform.position.x + dirMult * 0.05f, this.transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {

        }
    }
}
