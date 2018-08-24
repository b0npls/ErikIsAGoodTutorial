using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispyWoods : MonoBehaviour {
    Rigidbody2D rb;
    public Puff p;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity.Set(-1, 5);
	}
	public void shootPuff()
    {
        Puff newP = Instantiate(p, new Vector3(transform.position.x - 0.3f, transform.position.y - 0.35f), transform.rotation);
        newP.SetDirection(true);
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("puffTrigger");
        }

	}
}
