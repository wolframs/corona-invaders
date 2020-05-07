using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// Properties
    /// </summary>

    public Transform entryContainer;
    public Transform entryTemplate;

    public float templateHeight = 60f;

    public GameObject newHighScoreUI;
    public Button continueButton;
    public TMP_Text continueText;
    public TMP_Text playerNameText;

    public bool runDebugFunctions = false;
    private string scoreFilePath = "";

    [HideInInspector]
    public class ScoreEntries
    {
        public List<int> entryNo = new List<int>();
        public List<int> value = new List<int>();
        public List<string> playerName = new List<string>();

        public string GetString()
        {
            return JsonUtility.ToJson(this);
        }
    }

    /// <summary>
    /// Private Methods
    /// </summary>

    private void Start()
    {
        scoreFilePath = Application.persistentDataPath + "/scores.json";
        // Debug:
        if (runDebugFunctions)
            WriteDemoFile();

        if (entryContainer != null)
        // Ausführen, wenn das Script aus Score Scene eingebunden ist
        {
            PrintList(ReadScoreFile());
            return;
        }

        if (newHighScoreUI != null)
        // Ausführen, wenn das Script aus Game Over Scene eingebunden ist
        {
            bool isNewHighScore = CheckNewScore(ReadScoreFile());
            if (isNewHighScore)
            {
                newHighScoreUI.SetActive(true);
            } 
            else
            {
                continueButton.interactable = true;
                continueText.color = new Color(1, 1, 1, 1);
            }
            return;
        }
    }

    private ScoreEntries ReadScoreFile()
    {
        return JsonUtility.FromJson<ScoreEntries>(File.ReadAllText(scoreFilePath));
    }

    private void PrintList(ScoreEntries scoreList)
    {
        // Template ausblenden
        entryTemplate.gameObject.SetActive(false);

        for (int i = 0; i < scoreList.value.Count; i++)
        {
            // Aus Template neuen Eintrag erzeugen
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);

            // Eintrag um "templateHeight" auf y-Achse versetzen
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);

            // Textwerte setzen
            entryTransform.Find("posText").GetComponent<Text>().text = scoreList.entryNo[i].ToString();
            entryTransform.Find("scoreText").GetComponent<Text>().text = scoreList.value[i].ToString();
            entryTransform.Find("playerText").GetComponent<Text>().text = scoreList.playerName[i].ToString();

            // Eintrag aktivieren
            entryTransform.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Public Methods
    /// </summary>

    public bool CheckNewScore(ScoreEntries scoreList)
    {
        int newScore = PlayerPrefs.GetInt("lastScore", 0);

        if (scoreList.value.Count < 10)
            return true;

        for (int i = 0; i < scoreList.value.Count; i++)
        {
            if (newScore > scoreList.value[i])
                return true;
        }
        return false;
    }

    public void ContinueButton_OnClick()
    {
        // Nicht ausführen, wenn keine Highscore erreicht wurde:
        if (!newHighScoreUI.activeSelf)
        {
            PlayerPrefs.SetInt("lastScore", 0);
            SceneManager.LoadScene("Title");
            return;
        }
        else
        {
            PostNewScore();
        }

    }

    private void PostNewScore()
    {
        ScoreEntries scoreList = ReadScoreFile();
        int posOfNewScore = 0;
        int newScore = PlayerPrefs.GetInt("lastScore", 0);

        // Rank der neuen Score ermitteln:
        if (scoreList.value.Count < 10)
            posOfNewScore = scoreList.value.Count;

        for (int i = 0; i < scoreList.value.Count; i++)
        {
            if (newScore > scoreList.value[i])
            {
                posOfNewScore = i;
                break;
            }
        }

        // Platz 10 löschen, falls nötig:
        if(scoreList.entryNo.Count == 10)
        {
            scoreList.entryNo.RemoveAt(9);
            scoreList.value.RemoveAt(9);
            scoreList.playerName.RemoveAt(9);
        }

        // Neuen Eintrag machen:
        scoreList.entryNo.Insert(posOfNewScore, posOfNewScore + 1);
        scoreList.value.Insert(posOfNewScore, newScore);
        scoreList.playerName.Insert(posOfNewScore, playerNameText.text.ToUpper());

        // Nachfolgende Positionsnummern um 1 erhöhen:
        for (int i = (posOfNewScore + 1); i < scoreList.value.Count; i++)
        {
            scoreList.entryNo[i] += 1;
        }

        // Datei überschreiben:
        File.WriteAllText(scoreFilePath, scoreList.GetString());

        PlayerPrefs.SetInt("lastScore", 0);
        SceneManager.LoadScene("Scores");
    }

    public void WriteDemoFile()
    {
        string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        ScoreEntries demoEntries = new ScoreEntries();
        for (int i = 0; i < 10; i++)
        {
            // Zufälligen 3 char String erzeugen
            char[] nameChars = new char[3];

            for (int j = 0; j < nameChars.Length; j++)
            {
                nameChars[j] = validChars[UnityEngine.Random.Range(0, validChars.Length)];
            }

            string name = new string(nameChars);

            demoEntries.entryNo.Add(i + 1);
            demoEntries.value.Add(1150 - i * 85);
            demoEntries.playerName.Add(name);
        }

        File.WriteAllText(scoreFilePath, demoEntries.GetString());
        Debug.Log(scoreFilePath);
    }
}