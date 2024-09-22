using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpectedListUI : MonoBehaviour
{
    [SerializeField] private GameObject _expectedListContainer;
    [SerializeField] private Text _textPrefab;
   [SerializeField] List<MugshotController> _mugshotControllers;
    [SerializeField] List<TextMeshProUGUI> _textName;
    [SerializeField] List<TextMeshProUGUI> _textDepartment;
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

    public void NewUpdateExpectedList(List<CharacterScriptableObject> expectedWorkers)
    {
        int i = 0;
        foreach (CharacterScriptableObject worker in expectedWorkers)
        {
            if (_mugshotControllers[i] != null && i < 5)
            {
                UpdateSkin(worker, _mugshotControllers[i]);
                UpdateText(worker, _textName[i], _textDepartment[i]);
                i++;
            }
        }
        switch (i)
        {
            case 6: break;
            case 5: _mugshotControllers[5].gameObject.SetActive(false); break;
            case 4: _mugshotControllers[5].gameObject.SetActive(false); _mugshotControllers[4].gameObject.SetActive(false); break;
            case 3: _mugshotControllers[5].gameObject.SetActive(false); _mugshotControllers[4].gameObject.SetActive(false); _mugshotControllers[3].gameObject.SetActive(false); break;
        }
    }

    private void UpdateText(CharacterScriptableObject SO, TextMeshProUGUI textName, TextMeshProUGUI textDepartment)
    {
        textName.text = $"{SO.FirstName} {SO.LastName}";
        textDepartment.text = $"{SO.Department}";
    }
    private void UpdateSkin(CharacterScriptableObject SO, MugshotController Image)
    {
        Image.SetSkin(SO._material, SO.Head, SO.Eyes, SO.Nose,
                SO.Hair, SO.MouthClosed, SO.FrontEar, SO.BackEar, SO.Neck, SO.Body,
                SO.SholderBack, SO.SholderFront, SO.ForearmBack, SO.ForearmFront);
    }
}