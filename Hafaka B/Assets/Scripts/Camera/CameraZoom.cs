using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] float _zoomInFOV;

    Camera _camera;
    float _zoomOutFOV;

    private void Awake()
    {
        _camera = GetComponent<Camera>();    
    }

    void Start()
    {
        _zoomOutFOV = _camera.orthographicSize;    
    }

    public void ZoomIn()
    {
        _camera.orthographicSize = _zoomInFOV;
    }

    public void ZoomOut()
    {
        _camera.orthographicSize = _zoomOutFOV;
    }
}
