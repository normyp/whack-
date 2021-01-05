using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour {

	GameObject gameMan;
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
       		SceneManager.LoadScene("DeathScreen");
       	}
	}
}
