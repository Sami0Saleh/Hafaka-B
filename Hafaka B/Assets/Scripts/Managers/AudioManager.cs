using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _musicSource;
    [SerializeField] List<AudioSource> _SFXSources;

    [SerializeField, Range(0, 1)] float _musicVolume;
    [SerializeField, Range(0, 1)] float _SFXVolume;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        SetVoulumes();
    }

    private void SetVoulumes()
    {
        _musicSource.volume = _musicVolume;
        for (int i = 0; i < _SFXSources.Count; i++)
        {
            _SFXSources[i].volume = _SFXVolume;
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.clip = clip;
    }

    public void PlaySFX(AudioClip clip)
    {
        for (int i = 0; i < _SFXSources.Count; i++)
        {
            if(!_SFXSources[i].isPlaying)
            {
                _SFXSources[i].clip = clip;
                break;
            }
        }
        for (int i = 0; i < _SFXSources.Count; i++)
        {
            CreateNewAudioSource();
        }
        _SFXSources[_SFXSources.Count - 1].clip = clip;
    }

    private void CreateNewAudioSource()
    {
        _SFXSources.Add(Instantiate(_SFXSources[0]));
    }

    public void ChangeMusicVolume(Slider slider)
    {
        _musicVolume = slider.value;
        SetVoulumes();
    }

    public void ChangeSFXVolume(Slider slider)
    {
        _SFXVolume = slider.value;
        SetVoulumes();
    }
}
