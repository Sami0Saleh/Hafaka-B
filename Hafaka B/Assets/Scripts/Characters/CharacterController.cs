using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    [SerializeField] CharacterScriptableObject _characterSO;
    [SerializeField] SkinController _skin;
    [SerializeField] private float _speed;
    [SerializeField] TextBubble _textBubble;
    [SerializeField] private Transform _goal;
    [SerializeField] private Animator _animator;

    [Header("Text Files")]
    [SerializeField] TextAsset _defaultText;
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
    private bool _isDead = false;
    // visual 
    private List<GameObject> _characterSprites;
    private Sprite _bloodPool;
    //private Animator _animator;


    // ID info
    [Header("ID info")]
    private Sprite _idImage;
    private string _gender;
    private string _firstName;
    private string _lastName;
    private string _department;
    private string _jobTitle;
    private string _dateOfBirth;
    private bool _isExpected;

    private Vector2 MovePos;

    public bool IsAlien { get => _isAlien; }
    public Sprite IdImage { get => _idImage; private set => _idImage = value; }
    public string Gender { get => _gender; private set => _gender = value; }
    public string FirstName { get => _firstName; private set => _firstName = value; }
    public string LastName { get => _lastName; private set => _lastName = value; }
    public string Department { get => _department; private set => _department = value; }
    public string JobTitle { get => _jobTitle; private set => _jobTitle = value; }
    public string FullName { get => $"{FirstName} {LastName}"; }
    public string DateOfBirth { get => _dateOfBirth; private set => _dateOfBirth = value; }
    public CharacterScriptableObject CharacterSO { get => _characterSO; set => _characterSO = value; }
    public TextBubble TextBubble { get => _textBubble; }
    public bool IsDead { get => _isDead; set => _isDead = value; }
    public bool IsExpected { get => _isExpected; private set => _isExpected = value; }

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
        _speed = CharacterSO.MoveSpeed;
        _isAlien = CharacterSO.IsAlien;
        _characterSprites = CharacterSO.CharacterSprites;
        _bloodPool = CharacterSO.BloodPool;

        IdImage = CharacterSO.IdImage;
        FirstName = CharacterSO.FirstName;
        LastName = CharacterSO.LastName;
        Department = CharacterSO.Department;
        JobTitle = CharacterSO.JobTitle;
        DateOfBirth = CharacterSO.DateOfBirth;
        _skin.SetSkin(CharacterSO._material, CharacterSO.Head, CharacterSO.Eyes, CharacterSO.Nose, CharacterSO.Hair, CharacterSO.MouthClosed, CharacterSO.MouthOpenSmall, CharacterSO.MouthOpenBig, CharacterSO.FrontEar, CharacterSO.BackEar, CharacterSO.Neck, CharacterSO.Body, CharacterSO.SholderFront, CharacterSO.SholderBack, CharacterSO.ForearmFront, CharacterSO.ForearmBack, CharacterSO.KneeRight, CharacterSO.KneeLeft, CharacterSO.AnkleRight, CharacterSO.AnkleLeft, CharacterSO.FootRight, CharacterSO.FootLeft);
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
        _animator.SetFloat("Speed", 0);
        _isStopped = true;
    }

    public void ContinueToGoal()
    {
        if (!_isDead)
        {
            _animator.SetBool("IsSpeaking", false);
            _animator.SetFloat("Speed", 1);
            _isStopped = false;
        }
    }

    public void SetQuestionStr(string questionStr)
    {
        Debug.Log(questionStr);
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
            case "Name":
                _question = Questions.Name;
                break;
            case "Expected":
                _question = Questions.Expected;
                break;
            case "Date":
                _question = Questions.DateOfBirth;
                break;
            default:
                break;
        }
        Debug.Log(_question);
    }

    public void DisplayText()
    {
        _animator.SetBool("IsSpeaking", true);
        if (!_isAlien && !isSpecific() && IsExpected)
            _textBubble.TextToDisplay = ProvideGoodAnswer();
        else
            _textBubble.TextToDisplay = ProvideBadAnswer();
        _textBubble.gameObject.SetActive(true);
    }

    private string ProvideBadAnswer()
    {
        if (UnityEngine.Random.Range(0f, 1f) > 0.9f)
        {
            return AmbiguousAnswer();
        }
        switch (_question)
        {
            case Questions.Appearance:
                Debug.Log("broke");
                if (!CharacterSO.IsSpriteWrong) return _defaultText.text;
                break;
            case Questions.Department:
                Debug.Log("broke");
                if (!CharacterSO.IsDepartmentWrong) return _defaultText.text;
                break;
            case Questions.Position:
                Debug.Log("broke");
                if (!CharacterSO.IsPositionWrong) return _defaultText.text;
                break;
            case Questions.Name:
                Debug.Log("broke");
                if (!CharacterSO.IsFirstNameWrong) return _defaultText.text;
                break;
            case Questions.Expected:
                Debug.Log("broke");
                if (IsExpected || CharacterSO.IsAlien) return "Check again";
                else return "Had an emergency at work";
                break;
            case Questions.DateOfBirth:
                Debug.Log("broke");
                if (!CharacterSO.IsDateOfBirthWrong) return _defaultText.text;
                break;
            default:
                return "Bad Answer";
        }
        Debug.Log("specific answer");
        return _characterSO.SpecificAnswer;
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
            case Questions.Name:
                return _firstNameTexts.GetValueOrDefault(AnswerType.Ambiguous).text;
            case Questions.Expected:
                return _lastNameTexts.GetValueOrDefault(AnswerType.Ambiguous).text;
            case Questions.DateOfBirth:
                return _dateOfBirthTexts.GetValueOrDefault(AnswerType.Ambiguous).text;
            default:
                return "Ambiguous Answer";
        }
    }

    private string ProvideGoodAnswer()
    {
        if (UnityEngine.Random.Range(0f, 1f) > 0.9f)
        {
            return AmbiguousAnswer();
        }
        switch (_question)
        {
            case Questions.Appearance:
                return _appearanceTexts.GetValueOrDefault(AnswerType.Good).text;
            case Questions.Department:
                return _departmentTexts.GetValueOrDefault(AnswerType.Good).text;
            case Questions.Position:
                return _positionTexts.GetValueOrDefault(AnswerType.Good).text;
            case Questions.Name:
                return _firstNameTexts.GetValueOrDefault(AnswerType.Good).text;
            case Questions.Expected:
                return _lastNameTexts.GetValueOrDefault(AnswerType.Good).text;
            case Questions.DateOfBirth:
                return _dateOfBirthTexts.GetValueOrDefault(AnswerType.Good).text;
            default:
                return "Good Answer";
        }
    }

    private bool isSpecific()
    {
        switch (_question)
        {
            case Questions.Appearance:
                return CharacterSO.IsSpriteWrong;
            case Questions.Department:
                return CharacterSO.IsDepartmentWrong;
            case Questions.Position:
                return CharacterSO.IsPositionWrong;
            case Questions.Name:
                return CharacterSO.IsFirstNameWrong;
            case Questions.Expected:
                return IsExpected;
            case Questions.DateOfBirth:
                return CharacterSO.IsDateOfBirthWrong;
            default:
                return false;
        }
    }

    public void SetGoal(Transform goal)
    {
        _goal = goal;
    }

    public void Die()
    {
        _animator.SetBool("IsDead", true);
        _isDead = true;
        _isStopped = true;
        Debug.Log("Character " + FullName + " has died!");
        GoalRecorder.Instance.AddCharacterToListOfDead(this);
        Debug.Log(GoalRecorder.Instance.GetDeadCharacters()[0].FullName);
        StartCoroutine(KillCharacterCoroutine());

    }

    private IEnumerator KillCharacterCoroutine()
    {

        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }


   [ContextMenu("init")]
    public void Init(CharacterScriptableObject characterSO,bool isexpected)
    {
        _animator.SetBool("Reset", true);
        CharacterSO = characterSO;
        IsExpected = isexpected;
        _skin.SetSkin(CharacterSO._material, CharacterSO.Head, CharacterSO.Eyes, CharacterSO.Nose, CharacterSO.Hair, CharacterSO.MouthClosed, CharacterSO.MouthOpenSmall, CharacterSO.MouthOpenBig, CharacterSO.FrontEar, CharacterSO.BackEar, CharacterSO.Neck, CharacterSO.Body, CharacterSO.SholderFront, CharacterSO.SholderBack, CharacterSO.ForearmFront, CharacterSO.ForearmBack, CharacterSO.KneeRight, CharacterSO.KneeLeft, CharacterSO.AnkleRight, CharacterSO.AnkleLeft, CharacterSO.FootRight, CharacterSO.FootLeft); ;
        // Initialize movement and visual fields
        _speed = CharacterSO.MoveSpeed;
        _characterSprites = CharacterSO.CharacterSprites;
       // _animator = CharacterSO.Animator;
        _bloodPool = CharacterSO.BloodPool;

        // Initialize identity fields
        _idImage = CharacterSO.IdImage;
        _firstName = CharacterSO.FirstName;
        _lastName = CharacterSO.LastName;
        _gender = CharacterSO.Gender.ToString();
        _department = CharacterSO.Department;
        _jobTitle = CharacterSO.JobTitle;

        // Initialize alien-specific fields
        _isAlien = CharacterSO.IsAlien;

        // You can also initialize alien defects if needed:
        // _isSpriteWrong = _characterSO.IsSpriteWrong;
        // _isFirstNameWrong = _characterSO.IsFirstNameWrong;
        // _isLastNameWrong = _characterSO.IsLastNameWrong;
        // _isDepartmentWrong = _characterSO.IsDepartmentWrong;
        // _isPositionWrong = _characterSO.IsPositionWrong;
        // _isDateOfBirthWrong = _characterSO.IsDateOfBirthWrong;
    }
}

enum Questions
{
    Appearance,
    Department,
    Position,
    Name,
    Expected,
    DateOfBirth
}

public enum AnswerType
{
    Good,
    Bad,
    Ambiguous
}