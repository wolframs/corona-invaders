using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGeneral : MonoBehaviour
{
    private void Start() 
    {

    }

    private void Update()
    {
        CheckSelfDestroy();
    }
    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void EndGameFromSuccess()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void CheckSelfDestroy()
    {
        // Zum Debuggen ayayayaya
        if (Input.GetKeyDown(KeyCode.F10))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
