using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        }
    }

    public enum CallOption
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
        yield return new WaitForSeconds(1f);
        
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
        }
    }

    void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void OpenGameOptions()
    {

    }

    void CloseGameOptions()
    {

    }

}
