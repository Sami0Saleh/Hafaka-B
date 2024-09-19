using UnityEngine;

public class BobGraphicController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] BobCharacterController _bob;


    private void Update()
    {
        if(BobCharacterController.IsDeployed)
        {
            _animator.SetBool("IsDeployed", true);
            _animator.SetBool("IsAtStart", false);
        }
        if (BobCharacterController.IsAtStart)
        {
            _animator.SetBool("IsDeployed", false);
            _animator.SetBool("IsAtStart", true);
        }
        if (_bob.HasReachedTarget)
        {
            _animator.SetBool("IsDeployed", false);
            _animator.SetBool("HasReachedTarget", true);
        }
        if (_bob.IsReturning)
        {
            _animator.SetBool("IsReturning", false);
            _animator.SetBool("HasReachedTarget", false);
        }
    }

}
