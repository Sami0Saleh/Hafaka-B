using TMPro;
using UnityEngine;

public class Database : MonoBehaviour
{
    [SerializeField] CharacterScriptableObject CharacterSO1;
    [SerializeField] CharacterScriptableObject CharacterSO2;
    [SerializeField] CharacterScriptableObject CharacterSO3;

    [SerializeField] MugshotController image1;
    [SerializeField] TextMeshProUGUI LastName1;
    [SerializeField] TextMeshProUGUI FirstName1;
    [SerializeField] TextMeshProUGUI Gender1;
    [SerializeField] TextMeshProUGUI ID1;
    [SerializeField] TextMeshProUGUI DateOfBirth1;
    [SerializeField] TextMeshProUGUI Position1;
    [SerializeField] TextMeshProUGUI Features1;

    [SerializeField] MugshotController image2;
    [SerializeField] TextMeshProUGUI LastName2;
    [SerializeField] TextMeshProUGUI FirstName2;
    [SerializeField] TextMeshProUGUI Gender2;
    [SerializeField] TextMeshProUGUI ID2;
    [SerializeField] TextMeshProUGUI DateOfBirth2;
    [SerializeField] TextMeshProUGUI Position2;
    [SerializeField] TextMeshProUGUI Features2;

    [SerializeField] MugshotController image3;
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
        if (CharacterSO1 != null)
        {
            UpdateSkin(CharacterSO1, image1);
            LastName1.text = CharacterSO1.LastName;
            FirstName1.text = CharacterSO1.FirstName;
            Gender1.text = $"Gender: {CharacterSO1.Gender.ToString()}";
            ID1.text = $"ID: {CharacterSO1.ID}";
            DateOfBirth1.text = $"Birth Date: {CharacterSO1.DateOfBirth}";
            Position1.text = CharacterSO1.JobTitle;
            Features1.text = CharacterSO1.KeyFeatures;
        }

        if (CharacterSO2 != null)
        {
            UpdateSkin(CharacterSO2 , image2);  
            LastName2.text = CharacterSO2.LastName;
            FirstName2.text = CharacterSO2.FirstName;
            Gender2.text = $"Gender: {CharacterSO2.Gender.ToString()}";
            ID2.text = $"ID: {CharacterSO2.ID}";
            DateOfBirth2.text = $"Birth Date: {CharacterSO2.DateOfBirth}";
            Position2.text = CharacterSO2.JobTitle;
            Features2.text = CharacterSO2.KeyFeatures;
        }

        if (CharacterSO3 != null)
        {
            UpdateSkin (CharacterSO3 , image3);
            LastName3.text = CharacterSO3.LastName;
            FirstName3.text = CharacterSO3.FirstName;
            Gender3.text = $"Gender: {CharacterSO3.Gender.ToString()}";
            ID3.text = $"ID: {CharacterSO3.ID}";
            DateOfBirth3.text = $"Birth Date: {CharacterSO3.DateOfBirth}";
            Position3.text = CharacterSO3.JobTitle;
            Features3.text = CharacterSO3.KeyFeatures;
        }

    }

    private void UpdateSkin(CharacterScriptableObject SO, MugshotController Image)
    {
        Image.SetSkin(SO._material, SO.Head, SO.Eyes, SO.Nose,
                SO.Hair, SO.MouthClosed, SO.FrontEar, SO.BackEar, SO.Neck, SO.Body, 
                SO.SholderBack, SO.SholderFront, SO.ForearmBack, SO.ForearmFront);
    }
}
