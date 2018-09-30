using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collid)
    {
        if (collid.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            Destroy(transform.parent.gameObject);
        }
        else if (collid.gameObject.tag != gameObject.tag)
        {
            DamageTaker d = collid.GetComponent<DamageTaker>();
            if(d != null)
            {
                d.TakeDamage(1f, 50);
            } else
            {
                Debug.Log("What the heck");
            }
            Destroy(transform.parent.gameObject);
        }
    }
}
