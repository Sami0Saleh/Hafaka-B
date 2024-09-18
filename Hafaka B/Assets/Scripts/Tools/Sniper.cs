using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class Sniper : MonoBehaviour
{
    //[SerializeField] private Image _img;
    [SerializeField] private CameraZoom _scopeCamera;
    [SerializeField] private GameObject _reloadObj;
    [SerializeField] private TMP_Text _realodText;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip _shootClip;
    [SerializeField] private AudioClip _emptyClip;
    [SerializeField] private AudioClip _reloadClip;

    private RectTransform _canvasRectTransform;
    private bool _canSnipe = true;
    private Coroutine _currentCoroutine;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnCharacterClicked += Shoot;
        _scopeCamera.ZoomIn();
        if (AudioManager.Instance != null) AudioManager.Instance.ChangeMusicVolume(0.25f);
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnCharacterClicked -= Shoot;
        _scopeCamera.ZoomOut();
        if (AudioManager.Instance != null) AudioManager.Instance.ChangeMusicVolume(4f);
        Cursor.visible = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        else if(Input.GetMouseButtonDown(0))
        {
            if (_canSnipe)
            {
                if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(_shootClip);
                _canSnipe = false;
            }
            else
            {
                if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(_emptyClip);
                if(_currentCoroutine == null) ShowReloadText();
            }
        }
    }

    public void Shoot()
    {
        if (!_canSnipe)
        {
            if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(_emptyClip);
            ShowReloadText();
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

    private void ShowReloadText()
    {
        _reloadObj.SetActive(true);
        _realodText.DOFade(0f, 1f);
        _currentCoroutine = StartCoroutine(ReloadTextCoroutine());
    }

    public void Reload()
    {
        if (_canSnipe) return;
        _canSnipe = true;
        if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(_reloadClip);
    }

    private IEnumerator ReloadTextCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _reloadObj.SetActive(false);
        _realodText.DOFade(1f, 0.1f);
        _currentCoroutine = null;
    }
}
