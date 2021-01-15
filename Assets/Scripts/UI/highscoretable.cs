using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscoretable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    private int m_score;
    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        if (GameObject.Find("scoreman") == null)
        {
            m_score = 6181818;
        }
        else
        {
            m_score = GameObject.Find("scoreman").GetComponent<scoremanager>().s_score;
        }

        AddHighscore(m_score, "PNO");
        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString(("highscoreTable"));
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        /*Highscores highscores = new Highscores {highscoreEntryList = highscoreEntryList};
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));*/
    }

    private void AddHighscore(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry{score = score, name = name};
        
        string jsonString = PlayerPrefs.GetString(("highscoreTable"));
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        
        highscores.highscoreEntryList.Add(highscoreEntry);
        
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
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

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
    
    [System.Serializable] private class HighscoreEntry
    {
        public int score;
        public string name;
    }

}
