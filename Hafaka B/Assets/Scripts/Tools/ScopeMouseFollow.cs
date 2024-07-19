using UnityEngine;

public class ScopeMouseFollow : MonoBehaviour
{
    void Update()
    {
        transform.position = Input.mousePosition;
    }

}
