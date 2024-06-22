using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds, uiSounds;
    public AudioSource musicSource, sfxSource, uiSource;

    public string[] musicPlaylist;
    private int currentMusicIndex = 0;
    private bool musicStopped = false;

    private void Awake()
    {
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

    private void Start()
    {
        StartPlaylist();
    }

    private void Update()
    {
        if (!musicSource.isPlaying && !musicStopped)
        {
            PlayNextMusic();
        }
    }

    public void StartPlaylist()
    {

        musicStopped = false;

        if (musicPlaylist.Length > 0)
        {
            PlayMusic(musicPlaylist[currentMusicIndex]);
        }
        else
        {
            Debug.Log("Playlist is empty");
        }
    }

    public void PlayNextMusic()
    {
        currentMusicIndex = (currentMusicIndex + 1) % musicPlaylist.Length;
        PlayMusic(musicPlaylist[currentMusicIndex]);
    }

    public void PlayMusic(string name)
    {
        musicStopped = false;

        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying && !musicStopped)
        {
            musicStopped = true;

            musicSource.Stop();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlayUI(string name)
    {
        Sound s = Array.Find(uiSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            uiSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        uiSource.mute = !uiSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        uiSource.volume = volume;
    }
}
