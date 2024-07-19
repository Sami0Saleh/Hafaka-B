using UnityEngine;
using UnityEngine.Events;

public class CloseMenu : MonoBehaviour
{
    public UnityEvent ActivateViewScreen;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            ActivateViewScreen.Invoke();
        }    
    }
}
