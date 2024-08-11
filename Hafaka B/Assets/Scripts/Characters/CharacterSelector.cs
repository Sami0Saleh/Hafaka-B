using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] Image _indicatorImage;

    CharacterController _thisCharacter;
    private Ray ray;
    private RaycastHit2D hit;

    private void Start()
    {
        if (!TryGetComponent(out _thisCharacter))
            _thisCharacter = gameObject.AddComponent(typeof(CharacterController)) as CharacterController;
        DeactivateIndicator();
    }

    private void OnMouseDown()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null)
        {
            hit.collider.TryGetComponent(out _thisCharacter);
            GameManager.Instance.SetSelectedCharacter(_thisCharacter);
            ActivateIndicator();
        }
    }

    private void ActivateIndicator()
    {
        if(GameObject.Find("Sniper Screen").activeSelf)
        {
            Debug.Log("Sniping");
            return;
        }
        _indicatorImage.gameObject.SetActive(true);
    }

    public void DeactivateIndicator()
    {
        _indicatorImage.gameObject.SetActive(false);
    }
}