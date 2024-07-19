using UnityEngine;

public class ScrollCamera : MonoBehaviour
{
    [SerializeField] bool _isLeftScroller;
    [SerializeField] ScrollCamera[] _scrollers;

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

    private void OnMouseOver()
    {
        foreach (var scroller in _scrollers)
        {
            scroller.transform.position = new Vector2(scroller.transform.position.x + 1 * _direction * Time.deltaTime, scroller.transform.position.y);
        }
        _camera.transform.position = new Vector3(_camera.transform.position.x + 1 * _direction * Time.deltaTime, _camera.transform.position.y, _camera.transform.position.z);
    }
}
