using UnityEngine;

public class ScrollCamera : MonoBehaviour
{
    [SerializeField] float _scrollSpeed = 2;
    [SerializeField] bool _isLeftScroller;
    [SerializeField] ScrollCamera[] _scrollers;
    [SerializeField] GameObject _boundary;
    [SerializeField] Texture2D _mouseTexture;

    private int _direction = 1;
    private Camera _camera;
    private static bool _canMoveWithMouse = false;

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
        if (_canMoveWithMouse) return; // don't "double-move" if already moving with mouse
        float direction = Input.GetAxis("Horizontal");
        if (direction > 0)
        {
            if (transform.position.x >= _boundary.transform.position.x)
                return;
        }
        else
        {
            if (transform.position.x <= _boundary.transform.position.x)
                return;
        }
        if (direction != 0)
        {
            Debug.Log("Moving");
            Debug.Log(_canMoveWithMouse);
            foreach (var scroller in _scrollers)
            {
                scroller.transform.position = new Vector2(scroller.transform.position.x + _scrollSpeed * direction * Time.deltaTime, scroller.transform.position.y);
            }
            _camera.transform.position = new Vector3(_camera.transform.position.x + _scrollSpeed * direction * Time.deltaTime, _camera.transform.position.y, _camera.transform.position.z);
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
    
    private void OnMouseDrag()
    {
        _canMoveWithMouse = true;
        if (IsAheadOfBoundary()) return;
        _canMoveWithMouse = true;
        foreach (var scroller in _scrollers)
        {
            scroller.transform.position = new Vector2(scroller.transform.position.x + _scrollSpeed * _direction * Time.deltaTime, scroller.transform.position.y);
        }
        _camera.transform.position = new Vector3(_camera.transform.position.x + _scrollSpeed * _direction * Time.deltaTime, _camera.transform.position.y, _camera.transform.position.z);
    }

    private void OnMouseUp()
    {
        _canMoveWithMouse = false;
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(_mouseTexture, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        
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
