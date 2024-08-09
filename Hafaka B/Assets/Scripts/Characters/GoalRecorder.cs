using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoalRecorder : MonoBehaviour
{
    private CharacterController _cc;
    private List<CharacterController> _charactersWhoReachedGoal = new List<CharacterController>();
    private List<CharacterController> _deadCharacters = new List<CharacterController>();

    private int _finishedCharacters = 0;
    public int NumberOfHumans { get => _charactersWhoReachedGoal.Where(human => human.IsAlien == false).Count(); }
    public int NumberOfAliens { get => _charactersWhoReachedGoal.Where(human => human.IsAlien == true).Count(); }
    public static GoalRecorder Instance { get; private set; }
    public int FinishedCharacters { get => _finishedCharacters; set => _finishedCharacters = value; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out _cc))
            return;
        _charactersWhoReachedGoal.Add(_cc);
        foreach (var character in _charactersWhoReachedGoal)
        {
            Debug.Log("Number of humans: " + NumberOfHumans);
            Debug.Log("Number of aliens: " + NumberOfAliens);
        }
        if (_cc == GameManager.Instance.LastSelectedCharacter)
            GameManager.Instance.UnassignSelectedCharacter();
        Destroy(collision.gameObject);
        FinishedCharacters++;
    }

    public void AddCharacterToListOfDead(CharacterController cc)
    {
        CharacterController temp = cc;
        _deadCharacters.Add(temp);
        FinishedCharacters++;
    }

    public List<CharacterController> GetDeadCharacters()
    {
        return _deadCharacters;
    }
}
