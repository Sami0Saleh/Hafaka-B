using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScanID : MonoBehaviour
{
    [SerializeField] Image _idImage;
    [SerializeField] TMP_Text _name;
    [SerializeField] TMP_Text _department;
    [SerializeField] TMP_Text _position;
    [SerializeField] GameObject _viewPort;
    //[SerializeField] TMP_Text _dateOfBirth;

    private CharacterController _character;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnCharacterUnassignment += HideScanner;
        // don't display ID if there is no selected character
        if (GameManager.Instance.LastSelectedCharacter == null)
        {
            HideScanner();
            return;
        }
        _character = GameManager.Instance.LastSelectedCharacter;
        DisplayCharacterData();
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnCharacterUnassignment -= HideScanner;
    }

    public void DisplayCharacterData()
    {
        if (_character == null)
            return;
        _idImage.sprite = _character.IdImage;
        _name.text = $"{_character.FirstName} {_character.LastName}";
        _department.text = _character.Department;
        _position.text = _character.JobTitle;
        //_dateOfBirth.text = _character.
    }

    public void HideScanner()
    {
        gameObject.SetActive(false);
        _viewPort.SetActive(true);
    }
}
