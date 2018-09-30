using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispyWoods : MonoBehaviour, DamageTaker {
    Rigidbody2D rb;
    public Puff p;
    public Apple a;
    public string player;
    public float health = 100;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity.Set(-1, 5);
	}
    public void summonApple()
    {
        int dir = transform.rotation.y == 0 ? -1 : 1;
        float offset = Random.Range(3.3f, 6.6f);
        Apple newA = Instantiate(a, new Vector3(transform.position.x + offset * dir + Input.GetAxis("Horiz" + player) * 3, 6f), transform.rotation);
        newA.tag = tag;
        newA.delay = (int)Random.Range(0, 50);
    }
	public void shootPuff()
    {
        float rot = transform.rotation.y;
        Puff newP = Instantiate(p, new Vector3(transform.position.x - 0.3f, transform.position.y - 0.35f), transform.rotation);
        newP.SetDirection(rot == 0);
        newP.tag = tag;
    }
	// Update is called once per frame
	void Update () {
        Animator anim = GetComponent<Animator>();
        int hstun = anim.GetInteger("hitstun");
        if (hstun > 0) { anim.SetInteger("hitstun", hstun - 1); }
        if (Input.GetButtonDown("Fire1" + player))
        {
            anim.SetTrigger("puffTrigger");
        } else if(Input.GetButtonDown("Fire2"+player))
        {
            anim.SetTrigger("spinTrigger");
        }else if (Input.GetButtonDown("Fire3" + player))
        {
            anim.SetTrigger("appleTrigger");
        }

	}
    public void SpinMove (int frame)
    {
        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horiz" + player) * 0.1f * (15 - frame)/15f, this.transform.position.y); 
    }
    public  void TakeDamage(float damage, int hitstun)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetInteger("hitstun", hitstun);
        health -= damage;
    }
}
