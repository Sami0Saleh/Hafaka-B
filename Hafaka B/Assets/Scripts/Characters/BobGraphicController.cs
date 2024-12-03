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
            _animator.SetFloat("Speed", 1);
        }
        if (BobCharacterController.IsAtStart)
        {
            _animator.SetBool("IsDeployed", false);
            _animator.SetBool("IsAtStart", true);
            _animator.SetFloat("Speed", 0);
        }
        if (_bob.HasReachedTarget)
        {
            _animator.SetBool("IsDeployed", false);
            _animator.SetBool("HasReachedTarget", true);
            _animator.SetFloat("Speed", 0);
        }
        if (_bob.IsReturning)
        {
            _animator.SetBool("IsReturning", false);
            _animator.SetBool("HasReachedTarget", false);
            _animator.SetFloat("Speed", 1);
        }
     

            _animator.SetBool("IsSpeaking", BobCharacterController.IsTalking);
        
       
    }

}
