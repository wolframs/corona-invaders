using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public float SoundTimeoutTime;

    private void Start()
    {
        if(optionsMenu != null)
            optionsMenu.SetActive(false);
    }

    public void PerformMenuAction(string actionCalled)
    {
        switch (actionCalled)
        {
            case "play":
                StartCoroutine(SoundTimeout(CallOption.PlayGame));
                break;
            case "quit":
                StartCoroutine(SoundTimeout(CallOption.Quit));
                break;
            case "openOptions":
                StartCoroutine(SoundTimeout(CallOption.OpenOptions));
                break;
            case "closeOptions":
                StartCoroutine(SoundTimeout(CallOption.CloseOptions));
                break;
            case "openScores":
                StartCoroutine(SoundTimeout(CallOption.OpenScores));
                break;
            case "closeScores":
                StartCoroutine(SoundTimeout(CallOption.CloseScores));
                break;
        }
    }

    private enum CallOption
    {
        PlayGame,
        Quit,
        OpenOptions,
        CloseOptions,
        OpenScores,
        CloseScores
    }

    IEnumerator SoundTimeout(CallOption actionCalled)
    {
        yield return new WaitForSeconds(SoundTimeoutTime);
        
        switch (actionCalled)
        {
            case CallOption.PlayGame:
                PlayGame();
                break;
            case CallOption.Quit:
                Quit();
                break;
            case CallOption.OpenOptions:
                OpenGameOptions();
                break;
            case CallOption.CloseOptions:
                CloseGameOptions();
                break;
            case CallOption.OpenScores:
                OpenScores();
                break;
            case CallOption.CloseScores:
                CloseScores();
                break;
        }
    }

    void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    void Quit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    void OpenGameOptions()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    void CloseGameOptions()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    void OpenScores()
    {
        SceneManager.LoadScene("Scores");
    }

    void CloseScores()
    {
        SceneManager.LoadScene("Title");
    }

}
