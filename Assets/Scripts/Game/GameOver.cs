using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour {

	GameObject gameMan;
	//public GameObject deathScreen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gameMan = GameObject.FindWithTag("gameMan");
		lives player = gameMan.GetComponent<lives>();
       	int life = player._lives;

       	if(life == 0)
       	{
       		//deathScreen.SetActive(true);
       	}
	}
}
