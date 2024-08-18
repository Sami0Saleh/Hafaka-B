using UnityEngine;
using UnityEngine.UI;

public class Sniper : MonoBehaviour
{
    //[SerializeField] private Image _img;
    [SerializeField] private CameraZoom _scopeCamera;
    [SerializeField] private AudioClip _shootClip;
    [SerializeField] private AudioClip _reloadClip;

    private RectTransform _canvasRectTransform;
    private bool _canSnipe = true;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnCharacterClicked += Shoot;
        _scopeCamera.ZoomIn();
        AudioManager.Instance.ChangeMusicVolume(0.25f);
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnCharacterClicked -= Shoot;
        _scopeCamera.ZoomOut();
        AudioManager.Instance.ChangeMusicVolume(4f);
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
        AudioManager.Instance.PlaySFX(_shootClip);        
        BloodSpawner.Instance.SpawnBlood(GameManager.Instance.LastSelectedCharacter);
        GameManager.Instance.LastSelectedCharacter.Die();
        _canSnipe = false;
    }

    public void Reload()
    {
        if (_canSnipe) return;
        _canSnipe = true;
        AudioManager.Instance.PlaySFX(_reloadClip);
    }
}
