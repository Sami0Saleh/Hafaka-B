using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Database : MonoBehaviour
{
    [SerializeField] CharacterScriptableObject CharacterSO1;
    [SerializeField] CharacterScriptableObject CharacterSO2;
    [SerializeField] CharacterScriptableObject CharacterSO3;

    [SerializeField] Image image1;
    [SerializeField] TextMeshProUGUI LastName1;
    [SerializeField] TextMeshProUGUI FirstName1;
    [SerializeField] TextMeshProUGUI Gender1;
    [SerializeField] TextMeshProUGUI ID1;
    [SerializeField] TextMeshProUGUI DateOfBirth1;
    [SerializeField] TextMeshProUGUI Position1;
    [SerializeField] TextMeshProUGUI Features1;

    [SerializeField] Image image2;
    [SerializeField] TextMeshProUGUI LastName2;
    [SerializeField] TextMeshProUGUI FirstName2;
    [SerializeField] TextMeshProUGUI Gender2;
    [SerializeField] TextMeshProUGUI ID2;
    [SerializeField] TextMeshProUGUI DateOfBirth2;
    [SerializeField] TextMeshProUGUI Position2;
    [SerializeField] TextMeshProUGUI Features2;

    [SerializeField] Image image3;
    [SerializeField] TextMeshProUGUI LastName3;
    [SerializeField] TextMeshProUGUI FirstName3;
    [SerializeField] TextMeshProUGUI Gender3;
    [SerializeField] TextMeshProUGUI ID3;
    [SerializeField] TextMeshProUGUI DateOfBirth3;
    [SerializeField] TextMeshProUGUI Position3;
    [SerializeField] TextMeshProUGUI Features3;

    private void Start()
    {
        InsertIntoUI();
    }
    public void InsertIntoUI()
    {

        image1.sprite = CharacterSO1.IdImage;
        image2.sprite = CharacterSO2.IdImage;
        image3.sprite = CharacterSO3.IdImage;

        LastName1.text = CharacterSO1.LastName;
        LastName2.text = CharacterSO2.LastName;
        LastName3.text = CharacterSO3.LastName;
        
        FirstName1.text = CharacterSO1.FirstName;
        FirstName2.text = CharacterSO2.FirstName;
        FirstName3.text = CharacterSO3.FirstName;

        Gender1.text = $"Gender: {CharacterSO1.Gender.ToString()}";
        Gender2.text = $"Gender: {CharacterSO2.Gender.ToString()}";
        Gender3.text = $"Gender: {CharacterSO3.Gender.ToString()}";

        ID1.text = $"ID: {CharacterSO1.ID}";
        ID2.text = $"ID: {CharacterSO2.ID}";
        ID3.text = $"ID: {CharacterSO3.ID}";

        DateOfBirth1.text = $"Birth Date: {CharacterSO1.DateOfBirth}";
        DateOfBirth2.text = $"Birth Date: {CharacterSO2.DateOfBirth}";
        DateOfBirth3.text = $"Birth Date: {CharacterSO3.DateOfBirth}";

        Position1.text = CharacterSO1.JobTitle;
        Position2.text = CharacterSO2.JobTitle;
        Position3.text = CharacterSO3.JobTitle;

        Features1.text = CharacterSO1.KeyFeatures;
        Features2.text = CharacterSO2.KeyFeatures;
        Features3.text = CharacterSO3.KeyFeatures;
    }
}
