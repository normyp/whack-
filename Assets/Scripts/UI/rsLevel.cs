using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rsLevel : MonoBehaviour {

	public float timer = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timer >= 3.0f)
		{
			SceneManager.LoadScene("Whack!");
		}
		timer += Time.deltaTime;
	}
}
