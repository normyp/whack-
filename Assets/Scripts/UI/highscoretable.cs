using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscoretable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private int m_score;
    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        m_score = GameObject.Find("scoreman").GetComponent<scoremanager>().s_score;
        
        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry {score = m_score, name = "PNO"},
            new HighscoreEntry {score = 358462, name = "AAA"},
            new HighscoreEntry {score = 7000, name = "ANN"},
            new HighscoreEntry {score = 5, name = "CAT"},
            new HighscoreEntry {score = 31223, name = "DOG"},
            new HighscoreEntry {score = 6452, name = "JOE"},
            new HighscoreEntry {score = 4069, name = "JIM"},
            new HighscoreEntry {score = 49, name = "BOB"},
        };

        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {   
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(-47, -templateHeight * transformList.Count + 58);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH";
                break;
            case 1: rankString = "1ST";
                break;
            case 2: rankString = "2ND"; 
                break;
            case 3:
                rankString = "3RD";
                break;
        }
            
        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
            
        int score = highscoreEntry.score;
        //int score = GameObject.Find("scoreman").GetComponent<scoremanager>().s_score;
        //Debug.Log("Score is " + score);

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;

        entryTransform.Find("nameText").GetComponent<Text>().text = name;
        
        transformList.Add(entryTransform);
    }
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

}
