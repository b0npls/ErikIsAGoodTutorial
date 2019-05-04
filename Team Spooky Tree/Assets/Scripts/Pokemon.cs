using UnityEngine;
using System.Runtime.Serialization;
using System;

[Serializable]
public class Pokemon
{
    public string id;
    public TestEnum atk;
    public int def;
    public string name;
}