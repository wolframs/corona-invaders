using UnityEngine;
using UnityEngine.UI;

public class GameOverMusic : MonoBehaviour
{
    public AudioSource DefaultMusic;
    public AudioSource SuccessMusic;
    public AudioSource GameLostEffect;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("success") == 0)
        {
            GameLostEffect.Play();
            DefaultMusic.PlayDelayed(0.5f);
        }
        else
        {
            SuccessMusic.Play();
        }
    }

}
