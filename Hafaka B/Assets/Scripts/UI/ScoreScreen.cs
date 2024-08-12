using UnityEngine;
using TMPro;
using System;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField] TMP_Text _aliensKilledText;
    [SerializeField] TMP_Text _humansKilledText;
    [SerializeField] TMP_Text _aliensAliveText;
    [SerializeField] TMP_Text _rankText;
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
