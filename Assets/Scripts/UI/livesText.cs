using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesText : MonoBehaviour {

	Text text;
	public Texture tex;
	public GameObject gameMan;
	public lives player;

	private float x = 0.0f;
	// Use this for initialization
	void Start () {
		player = gameMan.GetComponent<lives>(); //Creates an instance of the spawner script so that score can be accessed
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		GameObject gameMan = GameObject.FindWithTag("gameMan"); //Creates an instance of mole manager so that the component spawner can be used
		text.text = "Lives: ";

	}

	private void OnGUI()
	{
		x = 70.0f;
		for (int i = 0; i < player._lives; i++)
		{
			GUI.DrawTexture(new Rect(x, 7.5f, 20.0f, 20.0f), tex, ScaleMode.ScaleToFit, true, 0);
			x += 30.0f;
		}

		x = 0.0f;
	}
}
