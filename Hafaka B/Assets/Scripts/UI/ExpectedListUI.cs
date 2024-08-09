using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpectedListUI : MonoBehaviour
{
    [SerializeField] private GameObject _expectedListContainer;
    [SerializeField] private Text _textPrefab;

    public void UpdateExpectedList(List<CharacterScriptableObject> expectedWorkers)
    {
        // Clear any existing UI elements
        foreach (Transform child in _expectedListContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // Add new items to the UI
        foreach (CharacterScriptableObject worker in expectedWorkers)
        {
            Text workerText = Instantiate(_textPrefab, _expectedListContainer.transform);
            workerText.text = $"{worker.FirstName} {worker.LastName} - {worker.JobTitle}\n";
        }
    }
}