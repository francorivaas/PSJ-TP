using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundClips
{
    Shoot, CarLock
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Music")]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField, Range(0, 1)] private float musicInitialVolumen;
    [SerializeField] private AudioClip music;

    [Header("Sounds")]
    [SerializeField] private AudioSource soundsAudioSource;
    [SerializeField] private AudioClip shoot;
    [SerializeField] private AudioClip carLock;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        musicAudioSource.volume = musicInitialVolumen;
        musicAudioSource.clip = music;
        musicAudioSource.Play();
    }

    public void PlaySound(SoundClips soundClip)
    {
        switch (soundClip)
        {
            case SoundClips.Shoot:
                soundsAudioSource.volume = 1f;
                soundsAudioSource.PlayOneShot(shoot);
                break;

            case SoundClips.CarLock:
                soundsAudioSource.volume = 0.3f;
                soundsAudioSource.PlayOneShot(carLock);
                break;

            default:
                break;
        }
    }
}
