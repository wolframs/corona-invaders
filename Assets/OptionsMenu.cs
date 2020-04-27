using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer MusicMixer;
    public AudioMixer SFXMixer;

    public void SetMusicVolume(float volume)
    {
        MusicMixer.SetFloat("volume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        SFXMixer.SetFloat("volume", volume);
    }
}
