using UnityEngine;
using TMPro;

public class TextBubble : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] float _typingSpeed = 0.07f, _displayTime = 1.5f;

    private bool _belongsToBob;

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

    private void Start()
    {
        if(transform.parent.GetComponent<BobCharacterController>() != null)
            _belongsToBob = true;
        else
            _belongsToBob = false;
    }

    private void DisplayText()
    {
        StartCoroutine(_text.TypeText(TextToDisplay, _typingSpeed, _displayTime, OnTextComplete));
    }

    public void OnTextComplete()
    {
        if (_belongsToBob)
        {
            BobCharacterController.TargetStartTalking(); //Bob stopped talking, chracter start talking
            Debug.Log("Belongs to Bob: " + _belongsToBob);
        }
        else
        {
            BobCharacterController.IsDeployed = false; //dialogue ended, return bob to post
            Debug.Log("Belongs to Bob: " + _belongsToBob);
        }
        gameObject.SetActive(false);
    }
}
