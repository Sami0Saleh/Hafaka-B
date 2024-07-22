using UnityEngine;
using UnityEngine.UI;

public class Sniper : MonoBehaviour
{
    //[SerializeField] private Image _img;
    [SerializeField] private CameraZoom _scopeCamera;

    private RectTransform _canvasRectTransform;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnCharacterClicked += Shoot;
        _scopeCamera.ZoomIn();
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnCharacterClicked -= Shoot;
        _scopeCamera.ZoomOut();
    }

    public void Shoot()
    {
        Debug.Log("SHOOT");
        if (GameManager.Instance.LastSelectedCharacter == null)
            return;
        GameManager.Instance.LastSelectedCharacter.Die();
    }
}
