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
            image1.SetSkin(CharacterSO1._material, CharacterSO1.Head, CharacterSO1.Eyes, CharacterSO1.Nose,
                CharacterSO1.Hair, CharacterSO1.MouthClosed, CharacterSO1.MouthOpenSmall, CharacterSO1.MouthOpenBig,
                CharacterSO1.FrontEar, CharacterSO1.BackEar, CharacterSO1.Neck, CharacterSO1.Body);
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
            image2.SetSkin(CharacterSO2._material, CharacterSO2.Head, CharacterSO2.Eyes, CharacterSO2.Nose,
                CharacterSO2.Hair, CharacterSO2.MouthClosed, CharacterSO2.MouthOpenSmall, CharacterSO2.MouthOpenBig,
                CharacterSO2.FrontEar, CharacterSO2.BackEar, CharacterSO2.Neck, CharacterSO2.Body);
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
            image3.SetSkin(CharacterSO3._material, CharacterSO3.Head, CharacterSO3.Eyes, CharacterSO3.Nose,
                CharacterSO3.Hair, CharacterSO3.MouthClosed, CharacterSO3.MouthOpenSmall, CharacterSO3.MouthOpenBig,
                CharacterSO3.FrontEar, CharacterSO3.BackEar, CharacterSO3.Neck, CharacterSO3.Body);
            LastName3.text = CharacterSO3.LastName;
            FirstName3.text = CharacterSO3.FirstName;
            Gender3.text = $"Gender: {CharacterSO3.Gender.ToString()}";
            ID3.text = $"ID: {CharacterSO3.ID}";
            DateOfBirth3.text = $"Birth Date: {CharacterSO3.DateOfBirth}";
            Position3.text = CharacterSO3.JobTitle;
            Features3.text = CharacterSO3.KeyFeatures;
        }

    }


}
