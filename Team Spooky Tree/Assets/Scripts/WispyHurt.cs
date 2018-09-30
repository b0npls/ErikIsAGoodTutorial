using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispyHurt : MonoBehaviour, DamageTaker {
    public void TakeDamage(float damage, int hitstun)
    {
        DamageTaker par = transform.parent.GetComponent<DamageTaker>();
        par.TakeDamage(damage, hitstun);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
