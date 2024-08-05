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
    [SerializeField] string _gender;
    [SerializeField] string _dateOfBirth;
    [SerializeField] string _department;
    [SerializeField] string _jobTitle;

    public float MoveSpeed { get => _moveSpeed; }
    public bool IsAlien { get => _isAlien; }
    public List<GameObject> CharacterSprites { get => _characterSprites; }
    public Animator Animator { get => _animator; }
    public Sprite BloodPool { get => _bloodPool; }
    public string FirstName { get => _firstName; }
    public string LastName { get => _lastName; }
    public string Gender { get => _gender;  }
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
    #endregion
}
