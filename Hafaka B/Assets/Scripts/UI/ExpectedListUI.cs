using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpectedListUI : MonoBehaviour
{
    [SerializeField] private GameObject _expectedListContainer;
    [SerializeField] private Text _textPrefab;
    private float _xPosition = -135f;
    private float _yPosition = 350f;
    private float _zPosition = 0f;


    public void UpdateExpectedList(List<CharacterScriptableObject> expectedWorkers)
    {
        
        // Add new items to the UI
        foreach (CharacterScriptableObject worker in expectedWorkers)
        {
            Text workerText = Instantiate(_textPrefab, _expectedListContainer.transform);
            workerText.transform.localPosition = new Vector3(_xPosition, _yPosition, _zPosition);
            workerText.text = $"{worker.FirstName} {worker.LastName} - {worker.JobTitle}";
            _yPosition -= 53f;
        }
    }
}