using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEditor;
public class CharacterController : MonoBehaviour
{
    [SerializeField] CharacterScriptableObject characterSO;
    [SerializeField] Transform Goal;
    [SerializeField] TextBubble _textBubble;
    [SerializeField] SerializableDictionary<AnswerType, TextAsset> _test;

    // variables
    private bool _isStopped = false;
    [SerializeField] private float _speed;
    private bool _isAlien;
    private Questions _question;

    // visual 
    private List<GameObject> _characterSprites;
    private Sprite _bloodPool;
    private Animator _animator;


    // ID info
    [Header("ID info")]
    private Sprite _idImage;
    private string _gender;
    private string _firstName;
    private string _lastName;
    private string _department;
    private string _jobTitle;

    private Vector2 MovePos;

    public bool IsAlien { get => _isAlien; }
    public Sprite IdImage { get => _idImage; private set => _idImage = value; }
    public string Gender { get => _gender; private set => _gender = value; }
    public string FirstName { get => _firstName; private set => _firstName = value; }
    public string LastName { get => _lastName; private set => _lastName = value; }
    public string Department { get => _department; private set => _department = value; }
    public string JobTitle { get => _jobTitle; private set => _jobTitle = value; }
    public string FullName { get => $"{FirstName} {LastName}"; }

    private void OnValidate()
    {
        _textBubble = GetComponentInChildren<TextBubble>(true);
    }

    void Start()
    {
        _speed = characterSO.MoveSpeed;
        _isAlien = characterSO.IsAlien;
        _characterSprites = characterSO.CharacterSprites;
        _bloodPool = characterSO.BloodPool;

        IdImage = characterSO.IdImage;
        FirstName = characterSO.FirstName;
        LastName = characterSO.LastName;
        Department = characterSO.Department;
        JobTitle = characterSO.JobTitle;
        
    }

    void Update()
    {
        if (!_isStopped)
        {
            float Direction = Mathf.Sign(Goal.position.x - transform.position.x);
            MovePos = new Vector2(
                transform.position.x + Direction * _speed * Time.deltaTime, //MoveTowards on 1 axis
                transform.position.y
            );
            transform.position = MovePos;
        }
        else
        {

        }
    }

    public void Stop()
    {
        _isStopped = true;
    }

    public void ContinueToGoal()
    {
        _isStopped = false;
    }

    public void SetQuestionStr(string questionStr)
    {
        switch (questionStr)
        {
            case "Appearance":
                _question = Questions.Appearance;
                break;
            case "Department":
                _question = Questions.Department;
                break;
            case "Position":
                _question = Questions.Position;
                break;
            case "First":
                _question = Questions.FirstName;
                break;
            case "Last":
                _question = Questions.LastName;
                break;
            case "Date":
                _question = Questions.DateOfBirth;
                break;
            default:
                break;
        }
    }

    public void DisplayText()
    {
        if (!_isAlien)
            _textBubble.TextToDisplay = ProvideGoodAnswer();
        else
            _textBubble.TextToDisplay = ProvideBadAnswer();
        _textBubble.gameObject.SetActive(true);
    }

    private string ProvideBadAnswer()
    {
        if (UnityEngine.Random.Range(0, 1) > 0.9f)
        {
            return AmbiguousAnswer();
        }
        return "Bad Answer";
    }

    private string AmbiguousAnswer()
    {
        return "Ambiguous Answer";
    }

    private string ProvideGoodAnswer()
    {
        return "Good Answer";
    }

    public void Die()
    {
        _isStopped = true;
        Debug.Log("Character " + FullName + " has died!");
        GoalRecorder.Instance.AddCharacterToListOfDead(this);
        Debug.Log(GoalRecorder.Instance.GetDeadCharacters()[0].FullName);
        Destroy(gameObject);
    }
}

enum Questions
{
    Appearance,
    Department,
    Position,
    FirstName,
    LastName,
    DateOfBirth
}

public enum AnswerType
{
    Good,
    Bad,
    Ambiguous
}