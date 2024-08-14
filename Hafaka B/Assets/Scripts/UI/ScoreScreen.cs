using UnityEngine;
using TMPro;
using System;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField] TMP_Text _aliensKilledText;
    [SerializeField] TMP_Text _humansKilledText;
    [SerializeField] TMP_Text _aliensAliveText;
    [SerializeField] TMP_Text _rankText;
    [SerializeField] TMP_Text _lawText;
    [SerializeField] UIManager _uiManager;

    private void OnEnable()
    {
        UdateUITexts();
        CloseOtherUI();
    }

    private void CloseOtherUI()
    {
        _uiManager.CloseAll();
    }

    private void UdateUITexts()
    {
        _aliensKilledText.text = GoalRecorder.Instance.NumberOfDeadAliens.ToString();
        _humansKilledText.text = GoalRecorder.Instance.NumberOfDeadHumans.ToString();
        _aliensAliveText.text = GoalRecorder.Instance.NumberOfAliens.ToString();
        _rankText.text = RankCalculator();
        _lawText.text = CreateNewLawText();
    }

    private string CreateNewLawText()
    {
        string law = "";
        switch (_rankText.text)
        {
            case "S":
                law = "Global satellite defense will be doubled!";
                break;
            case "A":
                law = "It's OK to be racist towards green people!";
                break;
            case "B":
                if (GoalRecorder.Instance.NumberOfAliens > 0)
                    law = "'People' with 3 eyes get free Healthcare.";
                else
                    law = "White House Security is now unprivatized.";
                break;
            case "C":
                if (GoalRecorder.Instance.NumberOfAliens > 0)
                    law = "Illegal aliens, now legal!";
                else
                    law = "We will start to think about gun control. Promise.";
                break;
            case "D":
                law = "";
                break;
            case "F":
                law = "Nuclear launch control is passed onto Lord Zorg!";
                break;
            default:
                break;
        }
        return $"New Bill: \"{law}\"";
    }

    private string RankCalculator()
    {
        int score = 8;
        score -= GoalRecorder.Instance.NumberOfDeadHumans;
        score -= GoalRecorder.Instance.NumberOfAliens;
        switch (score)
        {
            case 8:
                return "S";
            case 7:
                return "A";
            case 6:
            case 5:
                return "B";
            case 4:
            case 3:
                return "C";
            case 2:
                return "D";
            case 1:
            case 0:
                return "F";
            default:
                break;
        }
        return "F";
    }
}
