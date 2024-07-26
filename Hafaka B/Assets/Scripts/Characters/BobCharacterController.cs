using System;
using UnityEngine;

public class BobCharacterController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [Tooltip("Bob will stop at character's position + this value. Negative value for stopping on the left side")]
    [SerializeField] float _positionOffsetXAxis = -1;
    [SerializeField] Transform _startingSpot;

    private bool _isDeployed = false;
    private Vector3 _targetPosition;

    private void OnValidate()
    {
        GameObject tryFindTransformObject = GameObject.Find("Starting Spot");
        if (tryFindTransformObject == null) return;
        _startingSpot = tryFindTransformObject.transform;
    }

    private void Update()
    {
        if (GameManager.Instance.LastSelectedCharacter == null)
            _isDeployed = false;
        if (_isDeployed)
            MoveToCharacter();
        else
            ReturnToStartingSpot();
    }

    private void ReturnToStartingSpot()
    {
        transform.position = Vector2.MoveTowards(transform.position, _startingSpot.position, _moveSpeed * Time.deltaTime);
        _isDeployed = false;
    }

    private void StopSelectedCharacter()
    {
        GameManager.Instance.LastSelectedCharacter.Stop();
    }

    [ContextMenu("Move Bob")]
    public void MoveToCharacter()
    {
        _targetPosition = new Vector3(GameManager.Instance.LastSelectedCharacter.transform.position.x + _positionOffsetXAxis, transform.position.y, 0);
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }

    public void DeployBob() //call from unity events on question buttons
    {
        _isDeployed = true;
        if (GameManager.Instance.LastSelectedCharacter != null)
            StopSelectedCharacter();
    }
}
