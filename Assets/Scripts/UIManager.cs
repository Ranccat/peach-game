using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ScoreText;

    public void UpdateTimer(float time)
    {
        TimerText.text = time.ToString("F2");
    }

    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
    }
}
