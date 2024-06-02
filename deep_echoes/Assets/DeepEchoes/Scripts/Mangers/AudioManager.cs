using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public float backgroundMusicVolume = 0.3f;
    public float ambienceMusicVolume = 1.0f;
    public AudioClip backgroundMusic;
    public AudioClip ambienceMusic;
    
    private AudioSource audioSourceBackground;
    private AudioSource audioSourceAmbience;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  
            
            AudioSource[] audioSources = GetComponents<AudioSource>();
            audioSourceBackground = audioSources[0];
            audioSourceAmbience = audioSources[1];

            audioSourceBackground.clip = backgroundMusic;
            audioSourceAmbience.clip = ambienceMusic;

            // Configure audio sources (volume, loop, etc.)
            audioSourceBackground.loop = true;
            audioSourceBackground.volume = backgroundMusicVolume;
            
            audioSourceAmbience.loop = true;
            audioSourceAmbience.volume = ambienceMusicVolume;
            
            audioSourceBackground.Play();
            audioSourceAmbience.Play();
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    
    public void SetAmbienceVolume(float volume)
    {
        audioSourceAmbience.volume = volume;
    }

    public void SetBackgroundVolume(float volume)
    {
        audioSourceBackground.volume = volume;
    }

    public void SetVolume(float volume)
    {
        audioSourceAmbience.volume = volume;
        audioSourceBackground.volume = volume;
    }
}