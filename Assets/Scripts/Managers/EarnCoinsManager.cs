using System.Collections;
using UnityEngine;

public class EarnCoinsManager : MonoBehaviour
{
    [SerializeField] private const int DefaultScoreAdder = 5;
    [SerializeField] private const int BonusScoreAdder = 10;
    [SerializeField] private float _coinsMultiplier = 1f;

    [SerializeField] private Clickable _mainButton;
    [SerializeField] private BonusButtonsGeneration _bonusButtonsGenerator;
    [SerializeField] private ScoreController _scoreController;

    private void Start()
    {
        _mainButton.OnClick += OnButtonClicked;
        _bonusButtonsGenerator.OnButtonInstanceCreated += OnButtonInstanceCreated;
    }

    public void AddToMultiplier(float multiplier)
    {
        _coinsMultiplier += multiplier;
    }

    public void AddToMultiplierWithTime(float multiplier, float seconds)
    {
        _coinsMultiplier += multiplier;

        StartCoroutine(DecreaseMultiplier(multiplier, seconds));
    }

    public void AddToScoreWithoutMultiplier(int score)
    {
        int newScore = (int)(score * _coinsMultiplier) + _scoreController.CurrentScore;

        _scoreController.ChangeScore(newScore);
    }

    private void OnButtonInstanceCreated(Clickable instance)
    {
        instance.OnClick += OnButtonClicked;
    }

    private void OnButtonClicked(ICommand command)
    {
        command.Apply(this);
    }

    private IEnumerator DecreaseMultiplier(float multiplier, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        _coinsMultiplier -= multiplier;
    }
}
