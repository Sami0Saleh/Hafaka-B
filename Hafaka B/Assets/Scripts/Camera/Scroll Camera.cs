using UnityEngine;

public class ScrollCamera : MonoBehaviour
{
    [SerializeField] float _scrollSpeed = 2;
    [SerializeField] bool _isLeftScroller;
    [SerializeField] ScrollCamera[] _scrollers;
    [SerializeField] GameObject _boundary;

    private int _direction = 1;
    private Camera _camera;

    private void OnValidate()
    {
        _scrollers = FindObjectsOfType<ScrollCamera>();
    }

    private void Start()
    {
        _camera = Camera.main;
        if (_isLeftScroller)
            _direction = 1;
        else
            _direction = -1;
    }

    private void Update()
    {
        if (IsMouseNearEdge())
        {
            if (IsAheadOfBoundary()) return;
            foreach (var scroller in _scrollers)
            {
                scroller.transform.position = new Vector2(scroller.transform.position.x + _scrollSpeed * _direction * Time.deltaTime * -1, scroller.transform.position.y);
            }
            _camera.transform.position = new Vector3(_camera.transform.position.x + _scrollSpeed * _direction * Time.deltaTime * -1, _camera.transform.position.y, _camera.transform.position.z);
        }
    }

    private bool IsMouseNearEdge()
    {
        float edgeThreshold = 50f; // Pixels from the edge of the screen
        if (_isLeftScroller)
            return Input.mousePosition.x <= edgeThreshold;
        else
            return Input.mousePosition.x >= Screen.width - edgeThreshold;
    }




    private void OnMouseOver()
    {
        if (IsAheadOfBoundary()) return;
        foreach (var scroller in _scrollers)
        {
            scroller.transform.position = new Vector2(scroller.transform.position.x + _scrollSpeed * _direction * Time.deltaTime, scroller.transform.position.y);
        }
        _camera.transform.position = new Vector3(_camera.transform.position.x + _scrollSpeed * _direction * Time.deltaTime, _camera.transform.position.y, _camera.transform.position.z);
    }

    private bool IsAheadOfBoundary()
    {
        if (_direction == 1)
            return transform.position.x >= _boundary.transform.position.x;
        else
            return transform.position.x <= _boundary.transform.position.x;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(GetComponent<Collider2D>().bounds.center, GetComponent<Collider2D>().bounds.size);
    }
}
