using UnityEngine;

public class PlayClickSFX : MonoBehaviour
{
    [SerializeField] AudioClip _clip;

    public void PlayClip()
    {
        AudioManager.Instance.PlaySFX(_clip);
    }
}
