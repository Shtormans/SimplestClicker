using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _lastScore = 0;

    public int CurrentScore => _lastScore;

    public void ChangeScore(int score)
    {
        if (_lastScore != score)
        {
            _lastScore = score;

            _scoreText.text = ConvertScoreToString(score);
        }
    }

    private string ConvertScoreToString(float score)
    {
        return score.ToString();
    }
}
