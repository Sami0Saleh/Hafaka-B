using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] CharacterController _lastSelectedCharacter;
    [SerializeField] CharacterSpawner spawner;
    [SerializeField] GoalRecorder goalRecorder;
    [SerializeField] ScoreScreen _scoreScreen;
    [SerializeField] AudioClip _levelMusic;

    public static GameManager Instance { get; private set; }
    public CharacterController LastSelectedCharacter { get => _lastSelectedCharacter; private set => _lastSelectedCharacter = value; }
    public bool IsGameOver { get; private set; } = false;

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

    private void Start()
    {
        if(AudioManager.Instance != null)
            AudioManager.Instance.PlayMusic(_levelMusic);   
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
        Debug.Log(button.name.Split()[0]);
        Debug.Log(LastSelectedCharacter);
    }

    public void EndGame()
    {
        if (goalRecorder.FinishedCharacters >= spawner.CharacterCount)
        {
            Debug.Log("Game Over");
            IsGameOver = true;
            _scoreScreen.gameObject.SetActive(true);
        }
    }
}
