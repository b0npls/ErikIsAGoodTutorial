using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour, DamageTaker
{
    public string player;
    protected bool facingRight;
    public float health = 100;

    public int FramesActive { get; private set; }

    public virtual void SetFacingRight(bool direction)
    {
        if (facingRight == direction) return;
        facingRight = direction;
        if (facingRight)
        {
            gameObject.transform.rotation = new Quaternion(transform.rotation.x, 0f, transform.rotation.z, transform.rotation.w);
        }
        else
        {
            gameObject.transform.rotation = new Quaternion(transform.rotation.x, 180f, transform.rotation.z, transform.rotation.w);
        }
    }
    // Use this for initialization
    void Start()
    {
        FramesActive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FramesActive++;
    }

    public void TakeDamage(float damage, int hitstun)
    {
        health = health - damage;
    }
}
