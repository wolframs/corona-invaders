using UnityEngine;
using UnityEngine.UI;

public class IngameScore : MonoBehaviour
{
    public Text scoreIndicator;
    private int currentScore = 0;
    
    void Start()
    {
        InvokeRepeating("ScorePerSecond", 0f, 1.0f);
    }

    void ScorePerSecond()
    {
        currentScore += 10;
        scoreIndicator.text = currentScore.ToString();
    }

    public void ScoreEnemyDestroyed()
    {
        currentScore += 30;
        scoreIndicator.text = currentScore.ToString();
    }

    void OnDestroy()
    {
        // Score speichern:
        PlayerPrefs.SetInt("lastScore", currentScore);
        Debug.Log("Score saved: " + currentScore.ToString());
    }
}
