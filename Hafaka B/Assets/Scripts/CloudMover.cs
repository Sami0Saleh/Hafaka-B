using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [SerializeField] SerializableDictionary<GameObject, float> _cloudsAndSpeed = new SerializableDictionary<GameObject, float>();
    [SerializeField] float _minSpeed = 0.01f;
    [SerializeField] float _maxSpeed = 0.05f;

    private void OnValidate()
    {
        _cloudsAndSpeed.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            _cloudsAndSpeed.Add(transform.GetChild(i).gameObject, Random.Range(_minSpeed, _maxSpeed));
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var cloud in _cloudsAndSpeed)
        {
            cloud.Key.transform.position += cloud.Value * Time.deltaTime * Vector3.left;
        }
    }
}
