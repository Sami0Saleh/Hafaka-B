using UnityEngine;
using UnityEngine.UI;

public class Sniper : MonoBehaviour
{
    //[SerializeField] private Image _img;
    [SerializeField] private CameraZoom _scopeCamera;

    private RectTransform _canvasRectTransform;
    private bool _canSnipe = true;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public void Shoot()
    {
        if (!_canSnipe) return;
        Debug.Log("SHOOT");
        if (GameManager.Instance.LastSelectedCharacter == null)
            return;
        Debug.Log(BloodSpawner.Instance);
        
        BloodSpawner.Instance.SpawnBlood(GameManager.Instance.LastSelectedCharacter);
        GameManager.Instance.LastSelectedCharacter.Die();
        _canSnipe = false;
    }

    public void Reload()
    {
        _canSnipe = true;
    }
}
