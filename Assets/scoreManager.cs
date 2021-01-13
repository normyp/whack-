using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoremanager : MonoBehaviour
{
    // Start is called before the first frame update
    public int s_score;
    private GameObject entryScore;
    
    public string sceneName;
    public Scene currentScene;
    
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        entryScore = GameObject.Find("Mole Manager");
        Scene currentScene = SceneManager.GetActiveScene();
        //Debug.Log("Start scene is " + currentScene.name);
    }
    
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        //Debug.Log("Scene is " + currentScene.name);
        if(currentScene.name == "Whack!"){
            s_score = entryScore.GetComponent<gamelogic>().score;
        } 
           
    }
    
}
