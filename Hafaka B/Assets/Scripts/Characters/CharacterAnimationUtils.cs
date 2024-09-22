using UnityEngine;

public class CharacterAnimationUtils : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void ResetDeath()
    {
        animator.SetBool("IsDead", false);
    }

    public void FinishReset()
    {
        animator.SetBool("Reset", false);
    }
}
