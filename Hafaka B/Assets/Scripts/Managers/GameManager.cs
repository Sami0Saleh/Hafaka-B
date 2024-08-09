using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] CharacterController _lastSelectedCharacter;
    [SerializeField] CharacterSpawner spawner;
    [SerializeField] GoalRecorder goalRecorder;
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

    private void Update()
    {
        EndGame();
    }

    public void SetSelectedCharacter(CharacterController chr)
    {
        if (chr == null)
            return;
        if(LastSelectedCharacter != null)
        {
            LastSelectedCharacter.GetComponent<CharacterSelector>().DeactivateIndicator();
        }
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

    public void EndGame()
    {
        if (goalRecorder.FinishedCharacters == spawner.SpawnCount)
        {
            Debug.Log("Game Over");
        }
    }
}
