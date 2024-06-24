using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    CharacterController _thisCharacter;
    private Ray ray;
    private RaycastHit2D hit;

    private void Start()
    {
        if (!TryGetComponent(out _thisCharacter))
            _thisCharacter = gameObject.AddComponent(typeof(CharacterController)) as CharacterController;
    }

    private void OnMouseDown()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null)
        {
            hit.collider.TryGetComponent(out _thisCharacter);
            GameManager.Instance.SetSelectedCharacter(_thisCharacter);
        }
    }
}