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
        _aliensKilledText.text = GoalRecorder.Instance.NumberOfDeadAliens.ToString();
        _humansKilledText.text = GoalRecorder.Instance.NumberOfDeadHumans.ToString();
        _aliensAliveText.text = GoalRecorder.Instance.NumberOfAliens.ToString();
        _rankText.text = RankCalculator();
        _uiManager.CloseAll();
    }

    private string RankCalculator()
    {
        int score = 6;
        score -= GoalRecorder.Instance.NumberOfDeadHumans;
        score -= GoalRecorder.Instance.NumberOfAliens;
        switch (score)
        {
            case 6:
                return "S";
            case 5:
                return "A";
            case 4:
                return "B";
            case 3:
                return "C";
            case 2:
                return "C";
            case 1:
                return "D";
            case 0:
                return "F";
            default:
                break;
        }
        return "F";
    }
}
