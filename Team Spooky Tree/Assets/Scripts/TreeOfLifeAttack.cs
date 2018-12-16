using UnityEngine;
using System.Collections;

public class TreeOfLifeAttack : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collid)
    {
        if (collid.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            Debug.Log("grounded");
        }
        else if (collid.gameObject.tag != gameObject.tag)
        {
            DamageTaker d = collid.GetComponentInParent<DamageTaker>();
            if (d != null)
            {
                d.TakeDamage(1f, 50);
            }
            else
            {
                Debug.Log("What the heck");
            }
        }
    }
}
