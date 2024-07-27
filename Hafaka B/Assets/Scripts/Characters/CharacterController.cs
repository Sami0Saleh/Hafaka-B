using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    [SerializeField] CharacterScriptableObject _characterSO;
    [SerializeField] private float _speed;
    [SerializeField] Transform _goal;
    [SerializeField] TextBubble _textBubble;
    [SerializeField] SerializableDictionary<AnswerType, TextAsset> _appearanceTexts;
    [SerializeField] SerializableDictionary<AnswerType, TextAsset> _departmentTexts;
    [SerializeField] SerializableDictionary<AnswerType, TextAsset> _positionTexts;
    [SerializeField] SerializableDictionary<AnswerType, TextAsset> _firstNameTexts;
    [SerializeField] SerializableDictionary<AnswerType, TextAsset> _lastNameTexts;
    [SerializeField] SerializableDictionary<AnswerType, TextAsset> _dateOfBirthTexts;

    // variables
    private bool _isStopped = false;
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
        if(_appearanceTexts.Count == 0)
        {
            _appearanceTexts.Add(AnswerType.Good, null);
            _appearanceTexts.Add(AnswerType.Bad, null);
            _appearanceTexts.Add(AnswerType.Ambiguous, null);
        }

        if (_departmentTexts.Count == 0)
        {
            _departmentTexts.Add(AnswerType.Good, null);
            _departmentTexts.Add(AnswerType.Bad, null);
            _departmentTexts.Add(AnswerType.Ambiguous, null);
        }

        if (_positionTexts.Count == 0)
        {
            _positionTexts.Add(AnswerType.Good, null);
            _positionTexts.Add(AnswerType.Bad, null);
            _positionTexts.Add(AnswerType.Ambiguous, null);
        }

        if (_firstNameTexts.Count == 0)
        {
            _firstNameTexts.Add(AnswerType.Good, null);
            _firstNameTexts.Add(AnswerType.Bad, null);
            _firstNameTexts.Add(AnswerType.Ambiguous, null);
        }

        if (_lastNameTexts.Count == 0)
        {
            _lastNameTexts.Add(AnswerType.Good, null);
            _lastNameTexts.Add(AnswerType.Bad, null);
            _lastNameTexts.Add(AnswerType.Ambiguous, null);
        }

        if (_dateOfBirthTexts.Count == 0)
        {
            _dateOfBirthTexts.Add(AnswerType.Good, null);
            _dateOfBirthTexts.Add(AnswerType.Bad, null);
            _dateOfBirthTexts.Add(AnswerType.Ambiguous, null);
        }
    }

    void Start()
    {
        _speed = _characterSO.MoveSpeed;
        _isAlien = _characterSO.IsAlien;
        _characterSprites = _characterSO.CharacterSprites;
        _bloodPool = _characterSO.BloodPool;

        IdImage = _characterSO.IdImage;
        FirstName = _characterSO.FirstName;
        LastName = _characterSO.LastName;
        Department = _characterSO.Department;
        JobTitle = _characterSO.JobTitle;
        
    }

    void Update()
    {
        if (!_isStopped)
        {
            float Direction = Mathf.Sign(_goal.position.x - transform.position.x);
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
        switch (_question)
        {
            case Questions.Appearance:
                return _appearanceTexts.GetValueOrDefault(AnswerType.Bad).text;
            case Questions.Department:
                return _departmentTexts.GetValueOrDefault(AnswerType.Bad).text;
            case Questions.Position:
                return _positionTexts.GetValueOrDefault(AnswerType.Bad).text;
            case Questions.FirstName:
                return _firstNameTexts.GetValueOrDefault(AnswerType.Bad).text;
            case Questions.LastName:
                return _lastNameTexts.GetValueOrDefault(AnswerType.Bad).text;
            case Questions.DateOfBirth:
                return _dateOfBirthTexts.GetValueOrDefault(AnswerType.Bad).text;
            default:
                return "Bad Answer";
        }
    }

    private string AmbiguousAnswer()
    {
        switch (_question)
        {
            case Questions.Appearance:
                return _appearanceTexts.GetValueOrDefault(AnswerType.Ambiguous).text;
            case Questions.Department:
                return _departmentTexts.GetValueOrDefault(AnswerType.Ambiguous).text;
            case Questions.Position:
                return _positionTexts.GetValueOrDefault(AnswerType.Ambiguous).text;
            case Questions.FirstName:
                return _firstNameTexts.GetValueOrDefault(AnswerType.Ambiguous).text;
            case Questions.LastName:
                return _lastNameTexts.GetValueOrDefault(AnswerType.Ambiguous).text;
            case Questions.DateOfBirth:
                return _dateOfBirthTexts.GetValueOrDefault(AnswerType.Ambiguous).text;
            default:
                return "Ambiguous Answer";
        }
    }

    private string ProvideGoodAnswer()
    {
        switch (_question)
        {
            case Questions.Appearance:
                return _appearanceTexts.GetValueOrDefault(AnswerType.Good).text;
            case Questions.Department:
                return _departmentTexts.GetValueOrDefault(AnswerType.Good).text;
            case Questions.Position:
                return _positionTexts.GetValueOrDefault(AnswerType.Good).text;
            case Questions.FirstName:
                return _firstNameTexts.GetValueOrDefault(AnswerType.Good).text;
            case Questions.LastName:
                return _lastNameTexts.GetValueOrDefault(AnswerType.Good).text;
            case Questions.DateOfBirth:
                return _dateOfBirthTexts.GetValueOrDefault(AnswerType.Good).text;
            default:
                return "Good Answer";
        }
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