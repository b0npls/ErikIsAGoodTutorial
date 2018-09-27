using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudoWoSpecials : MonoBehaviour {

	public GameObject rockThrow;
	public float amountHealed = 7f;
	public GameObject slamTop, slamSide;

	// Attack 4
	public void RockThrow (){
		// Spawns rock at this location
		Vector3 overAndUp = new Vector3 (transform.position.x+1,transform.position.y+1,0f);
		GameObject rock = Instantiate (rockThrow) as GameObject;
		rock.transform.position = overAndUp;
	}

	// Attack 3
	public void Rest (){
		//regerate some amount of health at the end
		BonHealth myHealth = GetComponentInChildren<BonHealth>();
		myHealth.GainHealth(amountHealed);

	}

	// RockSpin (Attack 2) activates & deactivates hit boxes via Animator (no coding needed)

	// Attack1	
	public void Slam (){
		Vector3 location = new Vector3 (transform.position.x+1,transform.position.y+1,0f);
		GameObject hitBox = Instantiate (slamSide) as GameObject;
		hitBox.transform.position = location;
	}


}
