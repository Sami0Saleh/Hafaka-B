using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] CharacterScriptableObject characterSO;
    [SerializeField] Transform Goal;

    // variables
    private bool _isStopped = false;
    [SerializeField] private float _speed;
    private bool _isAlien;

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
}
