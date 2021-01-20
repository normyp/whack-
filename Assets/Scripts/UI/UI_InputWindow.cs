using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class UI_InputWindow : MonoBehaviour
{
    private Button_UI okBtn, cancelBtn;
    //private TextMeshPro titleText;
    public InputField inputField;
    private GameObject gameMan;
    private int m_score;
    private void Awake()
    {
        okBtn = transform.Find("okBtn").GetComponent<Button_UI>();
        cancelBtn = transform.Find("cancelBtn").GetComponent<Button_UI>();
        //titleText = transform.Find("titleText").GetComponent<TextMeshPro>();
        inputField = transform.Find("inputField").GetComponent<InputField>();
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
        if (Input.GetKeyDown((KeyCode.Return)) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            okBtn.ClickFunc();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cancelBtn.ClickFunc();
        }
    }

    public void Show(string inputString, string validCharacters, int charLimit, Action onCancel, Action<string> onOk)
    {
        gameObject.SetActive(true);
        //titleText.text = titleString;
        inputField.text = inputString;
        inputField.characterLimit = charLimit;
        inputField.onValidateInput = (string Text, int charIndex, char addedChar) =>
        {
            return ValidateChar(validCharacters, addedChar);
        };

        okBtn.ClickFunc = () =>
        {
            Hide();
            onOk(inputField.text);
        };

        cancelBtn.ClickFunc = () =>
        {
            Hide();
            onCancel();
        };
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private char ValidateChar(string validCharacters, char addedChar)
    {
        if (validCharacters.IndexOf(addedChar) != -1)
        {
            return addedChar;
        }
        else
        {
            return '\0';
        }
    }
}
