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

    [Header("Camera Shake")]
    [SerializeField] float _duration = 0.1f;
    [SerializeField] float _xPower = 0.1f;
    [SerializeField] float _yPower = 0.2f;

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
        StopAllCoroutines();
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
                StartCoroutine(CameraShake());
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
        StartCoroutine(CameraShake());
        if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(_shootClip);        
        BloodSpawner.Instance.SpawnBlood(GameManager.Instance.LastSelectedCharacter);
        GameManager.Instance.LastSelectedCharacter.Die();
        _canSnipe = false;
    }

    private IEnumerator CameraShake()
    {
        float elapsed = 0;
        float x;
        float y;
        Camera camera = Camera.main;
        Vector3 originalCameraPosition = camera.transform.localPosition;
        while (elapsed < _duration)
        {
            if (!gameObject.activeInHierarchy)
                break;
            x = UnityEngine.Random.Range(-0.1f, 0.1f) * _xPower;
            y = UnityEngine.Random.Range(-0.1f, 0.2f) * _yPower;
            camera.transform.localPosition += new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        camera.transform.localPosition = originalCameraPosition;
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
