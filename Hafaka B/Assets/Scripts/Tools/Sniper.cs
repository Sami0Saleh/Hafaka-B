using UnityEngine;
using UnityEngine.UI;

public class Sniper : MonoBehaviour
{
    //[SerializeField] private Image _img;
    [SerializeField] private CameraZoom _scopeCamera;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip _shootClip;
    [SerializeField] private AudioClip _emptyClip;
    [SerializeField] private AudioClip _reloadClip;

    private RectTransform _canvasRectTransform;
    private bool _canSnipe = true;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnCharacterClicked += Shoot;
        _scopeCamera.ZoomIn();
        if (AudioManager.Instance != null) AudioManager.Instance.ChangeMusicVolume(0.25f);
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnCharacterClicked -= Shoot;
        _scopeCamera.ZoomOut();
        if (AudioManager.Instance != null) AudioManager.Instance.ChangeMusicVolume(4f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        else if(Input.GetMouseButtonDown(0))
        {
            if(_canSnipe)
            {
                if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(_shootClip);
                _canSnipe = false;
            }
            else
                if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(_emptyClip);
        }
    }

    public void Shoot()
    {
        if (!_canSnipe)
        {
            if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(_emptyClip);
            return;
        }
        Debug.Log("SHOOT");
        if (GameManager.Instance.LastSelectedCharacter == null)
            return;
        if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(_shootClip);        
        BloodSpawner.Instance.SpawnBlood(GameManager.Instance.LastSelectedCharacter);
        GameManager.Instance.LastSelectedCharacter.Die();
        _canSnipe = false;
    }

    public void Reload()
    {
        if (_canSnipe) return;
        _canSnipe = true;
        if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(_reloadClip);
    }
}
