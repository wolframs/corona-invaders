using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;

    public TextAsset scoreFile;

    public float templateHeight = 60f;

    private ScoreEntries entries = new ScoreEntries();

    private void Awake()
    {
        // Ausführen verhindern, wenn das Script nicht aus der Score Scene eingebunden ist
        // (Wenn entryContainer nicht gefunden wird)
        if (entryContainer == null)
            return;

        WriteDemoFile();
        PrintList(ReadScoreFile());
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
                nameChars[j] = validChars[Random.Range(0, validChars.Length)];
            }
            string name = new string(nameChars);

            demoEntries.entryNo[i] = i + 1;
            demoEntries.value[i] = 1150 - i * 85;
            demoEntries.playerName[i] = name;  
        }

        File.WriteAllText(AssetDatabase.GetAssetPath(scoreFile), demoEntries.GetString());
    }

    private ScoreEntries ReadScoreFile()
    {
        return JsonUtility.FromJson<ScoreEntries>(scoreFile.text);
    }

    private void PrintList(ScoreEntries scoreList)
    {
        // Template ausblenden
        entryTemplate.gameObject.SetActive(false);

        for (int i = 0; i < 10; i++)
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

    public void CheckNewScore(int newScore)
    {

    }

    class ScoreEntries
    {
        public int[] entryNo = new int[10];
        public int[] value = new int[10];
        public string[] playerName = new string[10];

        public string GetString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}