using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {
	
 	public float timer = 0.0f;

	// Update is called once per frame
	void Update () {
		if(timer >= 3.0f)
		{
            SceneManager.LoadScene("Whack!");
        }
		timer += Time.deltaTime;
	}
}
