using UnityEngine;
using UnityEditor;

public abstract class DamageTaker2 : MonoBehaviour
{
    public abstract void TakeDamage(float damage, int hitstun);
}