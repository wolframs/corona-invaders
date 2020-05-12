using UnityEngine;
using UnityEngine.UI;

public class IngameScore : MonoBehaviour
{
    public Text scoreIndicator;

    // Aktuelle Punktzahl als Property definiert
    private int CurrentScore
    {
        get { 
            return _currentScore; 
        }
        set
        {
            _currentScore = value;
            // Beim Zuweisen eines Werts (set{}) automatisch ScoreIndicator updaten
            UpdateScoreIndicator(_currentScore);
        }
    }
    private int _currentScore = 0;

    void Start()
    {
        // Pro Sekunde +10 Punkte via wiederholender Funktion mit 1.0f*1000ms Intervall nach 0 Verzögerung
        InvokeRepeating("ScorePerSecond", 0f, 1.0f);
    }

    void ScorePerSecond()
    {
        CurrentScore += 10;
    }

    public void ScoreEnemyShot()
    {
        CurrentScore += 15;
    }

    public void ScoreEnemyDestroyed()
    {
        CurrentScore += 30;
    }

    private void UpdateScoreIndicator(int score)
    {
        scoreIndicator.text = score.ToString();
    }

    void OnDestroy()
    {
        // Score speichern, wenn GameObject mit diesem Skript zerstört wird (Scene Ende)
        PlayerPrefs.SetInt("lastScore", CurrentScore);
        Debug.Log("Score saved: " + CurrentScore.ToString());
    }
}
