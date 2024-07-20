using UnityEngine;
using UnityEngine.UI;

public class Sniper : MonoBehaviour
{
    //[SerializeField] private Image _img;
    //[SerializeField] private GameObject _scopeCamera;

    private RectTransform _canvasRectTransform;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnCharacterClicked += Shoot;
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnCharacterClicked -= Shoot;
    }

    void Start()
    {
        //_canvasRectTransform = _img.canvas.GetComponent<RectTransform>();
    }

    void Update()
    {
        //Vector2 localPoint;
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRectTransform, Input.mousePosition, Camera.main, out localPoint);
        //_img.rectTransform.localPosition = localPoint;
        //_scopeCamera.transform.position = _img.rectTransform.localPosition;
    }

    public void Shoot()
    {
        Debug.Log("SHOOT");
        if (GameManager.Instance.LastSelectedCharacter == null)
            return;
        GameManager.Instance.LastSelectedCharacter.Die();
    }
}
