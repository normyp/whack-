using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readKeyboard : MonoBehaviour
{
    public string stringtoedit = "Name";
    private TouchScreenKeyboard kb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnGUI() 
    {
        //stringtoedit = GUI.TextField(new Rect(10, 10, 200, 30), stringtoedit, 30);
        stringtoedit = GameObject.Find("SubmitName").GetComponent<InputField>().text;
        kb = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
