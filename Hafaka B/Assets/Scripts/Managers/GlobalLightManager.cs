using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Required for Light2D
using UnityEngine.Rendering; // Required for Light2D
using System.Collections.Generic;
using System;

public class Light2DColorTween : MonoBehaviour
{
    [SerializeField] private float _colorChangeRate = 1f;
    [SerializeField] private float _increment = 0.1f;
    [SerializeField] private CharacterSpawner _spawner;
    [SerializeField] private Volume _volume;
    [SerializeField] private List<Light2D> _lights;

    private float _progress = 0f;
    private int _count = 0;

    private void OnValidate()
    {
        _volume = GetComponent<Volume>();
    }

    private void OnEnable()
    {
        _spawner.OnCharacterSpawn += TweenLightColorIncrement;
    }

    private void OnDisable()
    {
        _spawner.OnCharacterSpawn -= TweenLightColorIncrement;
    }

    void Start()
    {
        _progress = 0f;
        _volume.weight = 0f;
    }

    [ContextMenu("Advance day light")]
    public void TweenLightColorIncrement()
    {
        if (_count++ == 0)
        {
            Debug.Log("skip on first spawn");
            return;
        }
        _progress += _increment;
        if (_progress > 0.4f)
        {
            ActivateLights();
            StrengthenLights();
        }
        DOTween.To(() => _volume.weight, x => _volume.weight = x, _progress, _colorChangeRate)
               .SetEase(Ease.Linear);
    }

    private void StrengthenLights()
    {
        foreach (var light in _lights)
        {
            light.intensity += 0.05f;
        }
    }

    private void ActivateLights()
    {
        foreach (var light in _lights)
        {
            if (light.gameObject.activeInHierarchy)
                continue;
            light.gameObject.SetActive(true);
            float tempIntensity = light.intensity;
            light.intensity = 0;
            DOTween.To(() => light.intensity, x => light.intensity = x, tempIntensity, _colorChangeRate)
               .SetEase(Ease.Linear);
        }
    }
}
