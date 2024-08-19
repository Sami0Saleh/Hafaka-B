using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeImageSize : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float _sizeMultiplier = 1.5f;

    private Vector2 originalLocalScale;


    private void Start()
    {
        originalLocalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale =  originalLocalScale*_sizeMultiplier;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalLocalScale;
    }
}
