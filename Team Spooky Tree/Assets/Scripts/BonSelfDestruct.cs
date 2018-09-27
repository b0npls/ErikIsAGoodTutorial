using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonSelfDestruct : MonoBehaviour {

	public float timeToDie = 1f;

	void Awake () {
		Destroy (gameObject, timeToDie);
	}
}
