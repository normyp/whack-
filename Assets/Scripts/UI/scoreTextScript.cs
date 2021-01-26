using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreTextScript : MonoBehaviour
{
    public int m_score;

    public string m_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("scoreman") == null)
        {
            m_score = 0;
        }
        else
        {
            m_score = GameObject.Find("scoreman").GetComponent<scoremanager>().s_score;    
        }

        GameObject.Find("scoreText").GetComponent<Text>().text = "Score: " + m_score;
    }
}
