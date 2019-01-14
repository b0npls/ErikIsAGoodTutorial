using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {

	//static so it stays even after the instances are gone. Public so any code can get to it.
	public static string Player1Choice;	
	public static string Player2Choice;

	public RectTransform selector;
	public string LeftRightMovement;
	public string UpDownMovement;
	public bool player1 = true;

	private string selectedCharacter;

	void Start () {
		Player1Choice = "Random";		//WARNING: These are statics! So each time this code starts,
		Player2Choice = "Random";		//it will reset the choices to Random.
	}
	

	void Update () {
		if (Input.GetButtonDown (LeftRightMovement)) {
			if (Input.GetAxis(LeftRightMovement) > 0){
				selector.position += new Vector3 (200,0,0);
			} else if (Input.GetAxis(LeftRightMovement) < 0){
				selector.position -= new Vector3 (200,0,0);
			}
		}
		if (Input.GetButtonDown (UpDownMovement)) {
			if (Input.GetAxis(UpDownMovement) > 0){
				selector.position += new Vector3 (0,200,0);
			} else if (Input.GetAxis(UpDownMovement) < 0){
				selector.position -= new Vector3 (0,200,0);
			}
		}

		if (selector.anchoredPosition.x < -200){
			selector.anchoredPosition = new Vector3 (200, selector.anchoredPosition.y, 0);
		}
		if (selector.anchoredPosition.x > 200){
			selector.anchoredPosition = new Vector3 (-200, selector.anchoredPosition.y, 0);
		}
		if (selector.anchoredPosition.y > -0.5f){
			selector.anchoredPosition = new Vector3 (selector.anchoredPosition.x, -200.5f, 0);
		}
		if (selector.anchoredPosition.y < -200.5f){
			selector.anchoredPosition = new Vector3 (selector.anchoredPosition.x, -0.5f, 0);
		}

		if (Input.GetButtonDown("Fire1P1") && player1 == true){
			Player1Choice = selectedCharacter;
		}
		if (Input.GetButtonDown("Fire1P2") && player1 == false){
			Player2Choice = selectedCharacter;
		}
		Debug.Log (Player1Choice);
		Debug.Log (Player2Choice);
	}

	void OnTriggerStay2D (Collider2D col){
		if (col.name != "P1 Selection" || col.name != "P2 Selection"){
			selectedCharacter = col.name;
		}

	}
}
