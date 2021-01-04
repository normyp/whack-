using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesText : MonoBehaviour {

	Text text;
	public GameObject gameMan;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		GameObject gameMan = GameObject.FindWithTag("gameMan"); //Creates an instance of mole manager so that the component spawner can be used
        lives player = gameMan.GetComponent<lives>(); //Creates an instance of the spawner script so that score can be accessed
        text.text = "Lives: " + player._lives;
	}
}
