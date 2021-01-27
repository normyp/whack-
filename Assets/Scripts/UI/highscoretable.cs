using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscoretable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    private List<HighscoreEntry> highscoreEntryList;
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
           //AddHighscore(m_score, "PNO");
        }
        entryTemplate.gameObject.SetActive(false);
        /*highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry {score = 30, name = "PNO"},
            new HighscoreEntry {score = 28, name = "AAA"},
            new HighscoreEntry {score = 25, name = "CRK"},
            new HighscoreEntry {score = 3, name = "BMM"},
            new HighscoreEntry {score = 23, name = "NIT"},
            new HighscoreEntry {score = 21, name = "TUN"},
            new HighscoreEntry {score = 15, name = "ABC"},
            new HighscoreEntry {score = 13, name = "FTT"},
            new HighscoreEntry {score = 10, name = "YJA"},
        };*/
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score >highscores.highscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        highscoreEntryTransformList = new List<Transform>();
        Debug.Log(highscores.highscoreEntryList.Count);
        int count = 0;
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            count++;
            if (count <= 5)
            {
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
        }
        /*
        Highscores highscores = new Highscores {highscoreEntryList = highscoreEntryList};
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));*/
    }

    public void AddHighscore(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry{score = score, name = name};
        
        string jsonString = PlayerPrefs.GetString(("highscoreTable"));
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        
        highscores.highscoreEntryList.Add(highscoreEntry);
        
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private void DeleteHighscore(string name)
    {
        PlayerPrefs.DeleteKey(name);
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
