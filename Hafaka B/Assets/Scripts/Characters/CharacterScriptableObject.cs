using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "Scriptable Objects/CharacterScriptableObject")]
public class CharacterScriptableObject : ScriptableObject
{
    [Header("Attributes")]
    [SerializeField] float _moveSpeed;
    [SerializeField] bool _isAlien;

    [Header("Visuals")]
    [SerializeField] List<GameObject> _characterSprites;
    [SerializeField] Animator _animator;
    [SerializeField] Sprite _bloodPool;

    [Header("ID")]
    [SerializeField] Sprite _idImage;
    [SerializeField] string _firstName;
    [SerializeField] string _lastName;
    [SerializeField] Genders _gender;
    [SerializeField] string id;
    [SerializeField] string _dateOfBirth;
    [SerializeField] string _department;
    [SerializeField] string _jobTitle;
    [SerializeField] string _keyFeatures;

    [Header("Character Type")]
    [SerializeField] private bool _isExpectedWorker;
    
    public float MoveSpeed { get => _moveSpeed; }
    public bool IsExpectedWorker { get => _isExpectedWorker; }
    public bool IsAlien { get => _isAlien; }
    public List<GameObject> CharacterSprites { get => _characterSprites; }
    public Animator Animator { get => _animator; }
    public Sprite BloodPool { get => _bloodPool; }
    public string FirstName { get => _firstName; }
    public string LastName { get => _lastName; }
    public Genders Gender { get => _gender;  }
    public string DateOfBirth { get => _dateOfBirth; }
    public string Department { get => _department; }
    public string JobTitle { get => _jobTitle; }
    public Sprite IdImage { get => _idImage; }

    [Header("Alien Defects")]
    #region AlienDefects
    [SerializeField] string _buffer = "Ignore this, don't delete";
    [field: SerializeField] public bool IsSpriteWrong { get; set; } = false;
    [field: SerializeField] public bool IsFirstNameWrong { get; set; } = false;
    [field: SerializeField] public bool IsLastNameWrong { get; set; } = false;
    [field: SerializeField] public bool IsDepartmentWrong { get; set; } = false;
    [field: SerializeField] public bool IsPositionWrong { get; set; } = false;
    [field: SerializeField] public bool IsDateOfBirthWrong { get; set; } = false;
    public string ID { get => id; set => id = value; }
    public string KeyFeatures { get => _keyFeatures; set => _keyFeatures = value; }
    #endregion
}

public enum Genders
{
    Male,
    Female,
    NonBinary
}
