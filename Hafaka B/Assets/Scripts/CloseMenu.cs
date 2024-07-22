using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CloseMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> _objectsToDeactivate = new();

    public UnityEvent ActivateViewScreen;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i < _objectsToDeactivate.Count; i++)
            {
                _objectsToDeactivate[i].SetActive(false);
            }
            ActivateViewScreen.Invoke();
            gameObject.SetActive(false);
        }    
    }
}
