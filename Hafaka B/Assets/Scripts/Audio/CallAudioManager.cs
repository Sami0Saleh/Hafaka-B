using UnityEngine;

public class CallAudioManager : MonoBehaviour
{
    
    public void TryPlayButtonSFX()
    {
        if (AudioManager.Instance == null) return;
        try
        {
            AudioManager.Instance.GetComponent<PlayClickSFX>().PlayClip();
        }
        catch (System.Exception)
        {

        }
    }
}
