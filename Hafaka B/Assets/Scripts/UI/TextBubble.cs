using UnityEngine;
using TMPro;

public class TextBubble : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] float _typingSpeed = 0.07f, _displayTime = 1.5f;

    public string TextToDisplay { private get; set; } = "";

    private void OnValidate()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _text.text = "";
        DisplayText();
    }

    private void OnDisable()
    {
        TextToDisplay = "";
    }

    private void DisplayText()
    {
        StartCoroutine(_text.TypeText(TextToDisplay, _typingSpeed, _displayTime, OnTextComplete));
    }

    public void OnTextComplete()
    {
        BobCharacterController.TargetStartTalking();
        gameObject.SetActive(false);
    }
}
