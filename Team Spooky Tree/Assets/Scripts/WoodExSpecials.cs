using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodExSpecials : MonoBehaviour {

	public string yMove;
	public GameObject apfelSeed;
	public GameObject fireSeed;
	public GameObject log;
	public GameObject leafshield;

	public float cooldownSeed = 5f;
	public float cooldownShield = 5f;
	public float lsLength = 2f;

	private float currentCDSeed = 0;
	private float currentCDShield = 0;
	private float currentLStime = 0;
	private Quaternion lsDefaultRot;

	void Start () {
		currentCDSeed = cooldownSeed;
		currentCDShield = cooldownShield;
		lsDefaultRot = leafshield.transform.rotation; 	
	}

	void Update () {
		currentCDSeed += Time.deltaTime;
		currentCDShield += Time.deltaTime;

		if (leafshield.activeSelf){
			currentLStime += Time.deltaTime;

			leafshield.transform.rotation = Quaternion.Euler(0,0,currentLStime*50);

			if (currentLStime >= lsLength){
				leafshield.SetActive(false);
				leafshield.transform.rotation = lsDefaultRot;
				currentCDShield = 0;
				currentLStime = 0;
			}
		}
	}

	void PlantSeed() {
		GameObject seed;
		float randomValue = Random.value;
		seed = apfelSeed;
		if (randomValue > 0.7){
			seed = fireSeed;
		}
		if (currentCDSeed >= cooldownSeed){
			GameObject plant = Instantiate(seed) as GameObject;
			plant.transform.position = gameObject.transform.position;
			currentCDSeed = 0f;
		} // not usable again until after previous tree is gone.
	}

	void LogRoll (){
		Vector3 offset = new Vector3 (0f,1.7f,0f);
        if (Input.GetAxis(yMove) < 0){
				offset = new Vector3 (0f,0.8f,0f);
        }
        GameObject weapon = Instantiate(log) as GameObject;
		weapon.transform.position = gameObject.transform.position + offset;
		weapon.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f,0f);
	}

	void LeafShield () {
		if (currentCDShield >= cooldownShield){
			leafshield.SetActive(true);
		}
		//should be useable while in the air. Leaf should have it's own animation
	}
}
