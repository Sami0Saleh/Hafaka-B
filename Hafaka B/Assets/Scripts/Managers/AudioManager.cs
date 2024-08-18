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
        Instance = this;

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        SetVoulumes();
    }

    private void SetVoulumes()
    {
        _musicSource.volume = Math.Clamp(_musicVolume, 0, 1);
        for (int i = 0; i < _SFXSources.Count; i++)
        {
            _SFXSources[i].volume = Math.Clamp(_SFXVolume, 0, 1);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        int sourceCount = _SFXSources.Count;
        for (int i = 0; i < sourceCount; i++)
        {
            if(!_SFXSources[i].isPlaying)
            {
                _SFXSources[i].clip = clip;
                _SFXSources[i].Play();
                return;
            }
        }
        for (int i = 0; i < sourceCount; i++)
        {
            CreateNewAudioSource();
        }
        _SFXSources[_SFXSources.Count - 1].clip = clip;
        _SFXSources[_SFXSources.Count - 1].Play();
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
    
    public void ChangeMusicVolume(float multiplier)
    {
        _musicVolume *= multiplier;
        SetVoulumes();
    }

    public void ChangeSFXVolume(Slider slider)
    {
        _SFXVolume = slider.value;
        SetVoulumes();
    }
}
