using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonHealth : MonoBehaviour {

	public float maxHealth = 100f;
	public float currentHealth = 100f;

	void Start () {
		currentHealth = maxHealth;
	}
	

	void Update () {
		UpToMax();
		DownToZero();
	}

	void UpToMax (){
		if (currentHealth > maxHealth){
			currentHealth = maxHealth;
		}
	}

	void DownToZero (){
		if (currentHealth <= 0){
			currentHealth = 0;
			// Player Loses!
		}
	}

	public void GainHealth (float value){
		currentHealth += value;
	}

	public void LoseHealth (float value){
		currentHealth -= value;
		SendMessage("Oucherino");
	}
}
