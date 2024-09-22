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
    [SerializeField] public Material _material;

    [Header("Head Renderers")]
    [SerializeField] public Sprite Head;
    [SerializeField] public Sprite Eyes;
    [SerializeField] public Sprite Nose;
    [SerializeField] public Sprite Hair;
    [SerializeField] public Sprite MouthClosed;
    [SerializeField] public Sprite MouthOpenSmall;
    [SerializeField] public Sprite MouthOpenBig;
    [SerializeField] public Sprite FrontEar;
    [SerializeField] public Sprite BackEar;
    [SerializeField] public Sprite Neck;

    [Header("Body Renderers")]
    [SerializeField] public Sprite Body;
    [SerializeField] public Sprite SholderFront;
    [SerializeField] public Sprite SholderBack;
    [SerializeField] public Sprite ForearmFront;
    [SerializeField] public Sprite ForearmBack;
    [SerializeField] public Sprite KneeRight;
    [SerializeField] public Sprite KneeLeft;
    [SerializeField] public Sprite AnkleRight;
    [SerializeField] public Sprite AnkleLeft;
    [SerializeField] public Sprite FootRight;
    [SerializeField] public Sprite FootLeft;

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
    [field: SerializeField] public bool IsNotOnExpectedList { get; set; } = false;
    [field: SerializeField] public bool IsDepartmentWrong { get; set; } = false;
    [field: SerializeField] public bool IsPositionWrong { get; set; } = false;
    [field: SerializeField] public bool IsDateOfBirthWrong { get; set; } = false;
    [field: SerializeField] public string SpecificAnswer { get; private set; }
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
