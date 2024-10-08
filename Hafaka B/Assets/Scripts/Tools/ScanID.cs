using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
using DG.Tweening;

public class ScanID : MonoBehaviour
{
    [SerializeField] MugshotController _idImage;
    [SerializeField] TMP_Text _name;
    [SerializeField] TMP_Text _department;
    [SerializeField] TMP_Text _position;
    [SerializeField] GameObject _viewPort;
    [SerializeField] TMP_Text _dateOfBirth;

    private CharacterController _character;
    private UIManager _uiManager;

    private void Start()
    {
        SetUIManager();
    }

    private void SetUIManager()
    {
        _uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnCharacterUnassignment += HideScanner;
            GameManager.Instance.OnCharacterClicked += SetAndDisplayCharacter;
        }
        // don't display ID if there is no selected character
        if (GameManager.Instance.LastSelectedCharacter == null)
        {
            if (_uiManager == null)
                SetUIManager();
            _uiManager.DisplayScannerFailedText();
            HideScanner();
            return;
        }
        SetAndDisplayCharacter();
    }

    private void SetAndDisplayCharacter()
    {
        _character = GameManager.Instance.LastSelectedCharacter;
        DisplayCharacterData();
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnCharacterUnassignment -= HideScanner;
            GameManager.Instance.OnCharacterClicked -= SetAndDisplayCharacter;
        }
    }

    public void DisplayCharacterData()
    {
        if (_character == null)
            return;
        UpdateSkin(_character.CharacterSO, _idImage);
        _name.text = $"{_character.FirstName} {_character.LastName}";
        _department.text = _character.Department;
        _position.text = _character.JobTitle;
        _dateOfBirth.text = _character.DateOfBirth;
    }

    public void HideScanner()
    {
        _viewPort.SetActive(true);
        gameObject.SetActive(false);
    }
    private void UpdateSkin(CharacterScriptableObject SO, MugshotController Image)
    {
        Debug.Log("Should Be Updating the hell out of this skin");
        Image.SetSkin(SO._material, SO.Head, SO.Eyes, SO.Nose,
                SO.Hair, SO.MouthClosed, SO.FrontEar, SO.BackEar, SO.Neck, SO.Body,
                SO.SholderBack, SO.SholderFront, SO.ForearmBack, SO.ForearmFront);
    }
}
