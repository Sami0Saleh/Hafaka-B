using UnityEngine;

public class BobCharacterController : MonoBehaviour
{
    private void Update()
    {
        MoveToCharacter();
    }
    [ContextMenu("Move Bob")]
    public void MoveToCharacter()
    {
        if (GameManager.Instance.LastSelectedCharacter == null)
            return;
        Vector2.MoveTowards(transform.position, GameManager.Instance.LastSelectedCharacter.transform.position, 1);
    }
}
