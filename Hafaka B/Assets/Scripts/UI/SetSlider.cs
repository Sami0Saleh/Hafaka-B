using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetSlider : MonoBehaviour
{
    [SerializeField] AudioSource _source;
    [SerializeField] Slider _slider;

    private void Awake()
    {
        _slider.GetComponent<Slider>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SetSliderAtEndOfFirstFrame());
    }

    IEnumerator SetSliderAtEndOfFirstFrame()
    {
        yield return new WaitForEndOfFrame();
        _slider.value = _source.volume;
    }

}
