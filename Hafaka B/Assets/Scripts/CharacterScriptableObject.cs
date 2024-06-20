using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "Scriptable Objects/CharacterScriptableObject")]
public class CharacterScriptableObject : ScriptableObject
{
    [Header("Attributes")]
    [SerializeField] float _moveSpeed;
    [SerializeField] bool _isAlien;

    [Header("Visuals")]
    [SerializeField] List<Sprite> _characterSprites;
    [SerializeField] Animator _animator;
    [SerializeField] Sprite _bloodPool;

    [Header("ID")]
    [SerializeField] string _firstName;
    [SerializeField] string _lastName;
    [SerializeField] string _gender;
    [SerializeField] string _dateOfBirth;
    [SerializeField] string _department;
    [SerializeField] string _jobTitle;
}
