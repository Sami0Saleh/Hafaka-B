using System;
using UnityEngine;

public class BobCharacterController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [Tooltip("Bob will stop at character's position + this value. Negative value for stopping on the left side")]
    [SerializeField] float _positionOffsetXAxis = -1;
    [SerializeField] Transform _startingSpot;
    [SerializeField] TextBubble _textBubble;

    private static bool _isDeployed = false;
    private bool _hasReachedTarget = false;
    private Vector3 _targetPosition;
    private string _textFile;

    public static bool IsDeployed { get => _isDeployed; set => _isDeployed = value; }

    private void OnValidate()
    {
        GameObject tryFindTransformObject = GameObject.Find("Starting Spot");
        if (tryFindTransformObject == null) return;
        _startingSpot = tryFindTransformObject.transform;
        _textBubble = GetComponentInChildren<TextBubble>(true);
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
        transform.position = Vector2.MoveTowards(transform.position, _startingSpot.position, _moveSpeed * Time.deltaTime);
        IsDeployed = false;
        _hasReachedTarget = false;
        HaveCharacterResumeWalking();
    }

    private static void HaveCharacterResumeWalking()
    {
        if (GameManager.Instance.LastSelectedCharacter == null) return;
        GameManager.Instance.LastSelectedCharacter.ContinueToGoal();
    }

    private void StopSelectedCharacter()
    {
        GameManager.Instance.LastSelectedCharacter.Stop();
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
            DisplayText();
            _hasReachedTarget = true;
        }
    }

    public void MoveToCharacter()
    {
        if (_hasReachedTarget) return;
        _targetPosition = new Vector3(GameManager.Instance.LastSelectedCharacter.transform.position.x + _positionOffsetXAxis, transform.position.y, 0);
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        CalculateDistanceToTarget();
    }

    public void DeployBob(TextFileHolder textFile) //call from unity events on question buttons
    {
        IsDeployed = true;
        _textFile = textFile.TextFile.text;
        if (GameManager.Instance.LastSelectedCharacter != null)
            StopSelectedCharacter();
    }

    public static void TargetStartTalking()
    {
        if (GameManager.Instance.LastSelectedCharacter == null) return;
        GameManager.Instance.LastSelectedCharacter.DisplayText();
    }
}
