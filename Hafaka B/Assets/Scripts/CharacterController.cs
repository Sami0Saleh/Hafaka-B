using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //[SerializeField] CharacterSO characterSO;
    
    // variables
    private float _speed;
    private bool _isAlien;

    // visual 
    private Sprite _characterSprite;
    private Sprite _bloodPool;
    private Animator _animator;


    // ID info
    [Header("ID info")]
    private string _gender;
    private string _firstName;
    private string _lastName;
    private string _department;
    private string _jobTitle;
    
    void Start()
    {
        //
        //_speed = characterSO.speed;
    }

    void Update()
    {
        
    }
}
