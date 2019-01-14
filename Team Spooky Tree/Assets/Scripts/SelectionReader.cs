using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionReader : MonoBehaviour {

	public bool player1 = true;

	private Text characterDisplay;
	private string playersCharacter;

	void Start () {
		characterDisplay = GetComponent<Text>();
	}
	

	void Update () {
		if (player1){
			playersCharacter = CharacterSelector.Player1Choice;
		}
		if (!player1){
			playersCharacter = CharacterSelector.Player2Choice;
		}
		characterDisplay.text = playersCharacter;
	}
}
