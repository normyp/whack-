using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changescenebutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void ChangeScene(string sceneName)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Leaderboard" && GameObject.Find("scoreman") != null)
        {
            GameObject.Find("scoreman").GetComponent<scoremanager>().clicked = true;
        }

        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
