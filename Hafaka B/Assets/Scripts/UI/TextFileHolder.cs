using UnityEngine;

public class TextFileHolder : MonoBehaviour
{
    [field: SerializeField] public TextAsset TextFile { get; private set; }
}
