using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BobCharacterController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [Tooltip("Bob will stop at character's position + this value. Negative value for stopping on the left side")]
    [SerializeField] float _positionOffsetXAxis = -1;
    [SerializeField] Transform _startingSpot;
    [SerializeField] TextBubble _textBubble;
    [SerializeField] Transform Graphics;

    private static CharacterController _targetCharacter;

    private static bool _isDeployed = false;
    private static bool _isAtStart = true;
    private bool _hasReachedTarget = false;
    private bool _isReturning = false;
    private Vector3 _targetPosition;
    private string _textFile;
    private Vector3 _bobScale;

    public static bool IsDeployed { get => _isDeployed; set => _isDeployed = value; }
    public bool HasReachedTarget { get => _hasReachedTarget; private set => _hasReachedTarget = value; }
    public static bool IsAtStart { get => _isAtStart; private set => _isAtStart = value; }
    public bool IsReturning { get => _isReturning; set => _isReturning = value; }

    private void OnValidate()
    {
        GameObject tryFindTransformObject = GameObject.Find("Starting Spot");
        if (tryFindTransformObject == null) return;
        _startingSpot = tryFindTransformObject.transform;
        _textBubble = GetComponentInChildren<TextBubble>(true);
    }

    private void Start()
    {
        _bobScale = transform.localScale;
    }

    private void Update()
    {
        if (GameManager.Instance.LastSelectedCharacter == null)
            IsDeployed = false;
        if (IsDeployed)
            MoveToCharacter();
        else
            ReturnToStartingSpot();
    }

    private void ReturnToStartingSpot()
    {
        _isReturning = true;
        transform.position = Vector2.MoveTowards(transform.position, _startingSpot.position, _moveSpeed * Time.deltaTime);
        IsDeployed = false;
        HasReachedTarget = false;
        HaveCharacterResumeWalking();
        if (!IsAtStart && MathF.Abs(_startingSpot.position.x - transform.position.x) <= 0.1f)
        {
            //FlipCharacter();
            transform.localScale = _bobScale;
            IsAtStart = true;
        }
    }

    private static void HaveCharacterResumeWalking()
    {
        if (_targetCharacter == null) return;
        _targetCharacter.ContinueToGoal();
        GameManager.Instance.LastSelectedCharacter.ContinueToGoal();
    }

    private void StopSelectedCharacter()
    {
        if (_targetCharacter == null) return;
        _targetCharacter.Stop();
    }

    private void DisplayText()
    {
        _textBubble.TextToDisplay = _textFile;
        _textBubble.gameObject.SetActive(true);
    }
    private void CalculateDistanceToTarget()
    {
        if (MathF.Abs(_targetPosition.x - transform.position.x) <= 0.1f)
        {
            FlipCharacter();
            DisplayText();
            HasReachedTarget = true;
        }
    }

    [ContextMenu("Flip")]
    private void FlipCharacter()
    {
        Graphics.localScale = new Vector3(Graphics.localScale.x * -1, Graphics.localScale.y, Graphics.localScale.z);
    }

    public void MoveToCharacter()
    {
        if (HasReachedTarget) return;
        IsAtStart = false;
        _targetPosition = new Vector3(_targetCharacter.transform.position.x + _positionOffsetXAxis, transform.position.y, 0);
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        CalculateDistanceToTarget();
    }

    public void DeployBob(TextFileHolder textFile) //call from unity events on question buttons
    {
        if (IsDeployed) return;
        transform.localScale = _bobScale;
        IsDeployed = true;
        _textFile = textFile.TextFile.text;
        if (GameManager.Instance.LastSelectedCharacter != null)
        {
            _targetCharacter = GameManager.Instance.LastSelectedCharacter;
            StopSelectedCharacter();
        }
    }

    public static void TargetStartTalking()
    {
        if (_targetCharacter == null) return;
        _targetCharacter.DisplayText();
    }
}
