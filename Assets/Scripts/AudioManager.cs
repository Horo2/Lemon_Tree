using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource musicEffect;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        this.gameObject.transform.position = FindAnyObjectByType<XROrigin>().gameObject.transform.position;
    }

    public void PlayMusic(AudioClip musicClip, float volume = 1.0f)
    {
        musicSource.clip = musicClip;
        musicSource.volume = volume;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip sfxClip, float volume = 1.0f)
    {
        sfxSource.PlayOneShot(sfxClip, volume);
    }

    public void PlayMusicEffect(AudioClip sfxClip, float volume = 1.0f)
    {
        musicEffect.clip = sfxClip;
        musicEffect.Play();
        if (musicEffect.time > 20)
        {
            musicEffect.Stop();
        }
    }


    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
