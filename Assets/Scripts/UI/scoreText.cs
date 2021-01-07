using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoretext : MonoBehaviour {

	Text text;
	public GameObject moleMan;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		GameObject moleMan = GameObject.FindWithTag("man"); //Creates an instance of mole manager so that the component spawner can be used
        gamelogic game = moleMan.GetComponent<gamelogic>(); //Creates an instance of the spawner script so that score can be accessed
		text.text = "Score: " + game.score;
	}
}
