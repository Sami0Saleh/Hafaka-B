using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeImageSize : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float _sizeMultiplier = 1.5f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale *= _sizeMultiplier;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale /= _sizeMultiplier;
    }
}
