using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] CharacterController _lastSelectedCharacter;

    public static GameManager Instance { get; private set; }
    public CharacterController LastSelectedCharacter { get => _lastSelectedCharacter; private set => _lastSelectedCharacter = value; }

    public event Action OnCharacterUnassignment;
    public event Action OnCharacterClicked;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void SetSelectedCharacter(CharacterController chr)
    {
        if (chr == null)
            return;
        LastSelectedCharacter = chr;
        OnCharacterClicked?.Invoke();
    }

    public void UnassignSelectedCharacter()
    {
        LastSelectedCharacter = null;
        OnCharacterUnassignment?.Invoke();
    }

    public void SetQuestionOnSelectedCharacter(Button button)
    {
        if (LastSelectedCharacter == null) return;
        LastSelectedCharacter.SetQuestionStr(button.name.Split()[0]);
    }
}
