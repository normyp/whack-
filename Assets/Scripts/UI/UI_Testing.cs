using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using CodeMonkey;
using UnityEngine;

public class UI_Testing : MonoBehaviour
{
    public highscoretable _highscoretable;
    public int m_score;
    public string inputText;
    
    [SerializeField] private UI_InputWindow inputWindow;

    private void Start()
    {
        _highscoretable = GameObject.Find("HighscoreTable").GetComponent<highscoretable>();
        transform.Find("submitScoreBtn").GetComponent<Button_UI>().ClickFunc = ( ) => { 
            inputWindow.Show( "Enter name", "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 3,
                () =>
            {
                CMDebug.TextPopupMouse("Cancel!");
            }, (inputText) =>
            {
                CMDebug.TextPopupMouse("Ok: " + inputText);
                if (GameObject.Find("scoreman") == null)
                {

                }
                else
                {
                    _highscoretable.AddHighscore(m_score, inputText);
                }
            });
        };
    }

    private void Update()
    {
        if (GameObject.Find("scoreman") == null)
        {

        }
        else
        {
            m_score = GameObject.Find("scoreman").GetComponent<scoremanager>().s_score;    
        }
    }
}
