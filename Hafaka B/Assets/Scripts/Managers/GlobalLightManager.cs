using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Required for Light2D

public class Light2DColorTween : MonoBehaviour
{
    [SerializeField] private Light2D _light2D;
    [SerializeField] private Color _startingColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private float _colorChangeRate = 1f;
    [SerializeField] private float _increment = 0.1f;
    [SerializeField] private CharacterSpawner _spawner;

    private float _progress = 0f;

    private void OnValidate()
    {
        
    }

    void Start()
    {
        _light2D.color = _startingColor;
        _progress = 0f;
        _increment = Mathf.Min(0, 10 / _spawner.CharacterCount);
    }

    [ContextMenu("Advance day light")]
    public void TweenLightColorIncrement()
    {
        if (_progress >= 1f)
        {
            Debug.Log("Color is already at or near the target color.");
            return;
        }

        float newProgress = Mathf.Clamp01(_progress + _increment);

        Color nextColor = Color.Lerp(_startingColor, _endColor, newProgress);

        DOTween.To(() => _light2D.color, x => _light2D.color = x, nextColor, _colorChangeRate)
               .SetEase(Ease.Linear);

        _progress = newProgress;
    }
}
