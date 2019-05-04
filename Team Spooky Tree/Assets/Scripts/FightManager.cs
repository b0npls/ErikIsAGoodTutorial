using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour {
    private Fighter Player1Char;
    private Fighter Player2Char;

    public Image p1Health;
    public Image p2Health;
    public Text winText;

    private bool matchRunning = true;

    private string[] paths = { "WispyWoods", "TreeOfLife", "Woodman Exe", "Tree", "Giver", "Sudowoodo" };

    // Use this for initialization
    void Start () {
        string path1 = "";
        string path2 = "";
	    if(CharacterSelector.Player1Choice == "Random")
        {
            path1 = paths[1]; //paths[ Random.Range(0, 6)];
        }
        if (CharacterSelector.Player2Choice == "Random")
        {
            path2 = paths[5];
        }
        //path1 = "TreeOfLife";
        GameObject p1Go = (GameObject)Instantiate(Resources.Load(path1));
        Player1Char = p1Go.GetComponent<Fighter>();
        Player1Char.transform.Translate(new Vector3(-3f, 0f));
        Fighter e = Player1Char.GetComponent<Fighter>();
        e.player = "P1";
        
        GameObject p2Go = (GameObject)Instantiate(Resources.Load(path2));
        Player2Char = p2Go.GetComponent<Fighter>();
        Player2Char.transform.Translate(new Vector3(3f, 0f));
        Player2Char.transform.Rotate(new Vector3(0f, 180f, 0f));
        foreach(Transform t in Player2Char.GetComponentsInChildren<Transform>())
        {
            t.tag = "Player2";
        }
        Fighter d = Player2Char.GetComponent<Fighter>();
        d.player = "P2";
        Debug.Log(Player1Char.ToString());
	}
	
	// Update is called once per frame
	void Update () {
        if (matchRunning)
        {
            if (Player1Char.transform.position.x < Player2Char.transform.position.x)
            {
                Player1Char.SetFacingRight(true);
                Player2Char.SetFacingRight(false);
            }
            else
            {
                Player1Char.SetFacingRight(false);
                Player2Char.SetFacingRight(true);
            }

            p1Health.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 2 * Player1Char.health);
            p2Health.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 2 * Player2Char.health);

            if (Player1Char.health <= 0)
            {
                Destroy(Player1Char.gameObject);
                matchRunning = false;
            }
            if (Player2Char.health <= 0)
            {
                Destroy(Player2Char.gameObject);
                matchRunning = false;
            }
        } else
        {
            winText.enabled = true;
        }
	}
}
