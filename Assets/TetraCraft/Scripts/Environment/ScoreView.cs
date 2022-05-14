using TMPro;
using UnityEngine;
using Zenject;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _clearedLinesView;
    [SerializeField] private TextMeshProUGUI _levelView;
    [SerializeField] private TextMeshProUGUI _scoreValueView;

    private Score _scoreModel;

    [Inject]
    public void Constructor(Score scoreModel)
    {
        _scoreModel = scoreModel;
    }

    private void OnEnable()
    {
        _scoreModel.ScoreUpdated += OnScoreUpdated;
    }

    private void OnDisable()
    {
        _scoreModel.ScoreUpdated -= OnScoreUpdated;
    }

    private void OnScoreUpdated()
    {
        _clearedLinesView.text = _scoreModel.ClearedLinesCount.ToString();
        _levelView.text = _scoreModel.Level.ToString();
        _scoreValueView.text = _scoreModel.ScoreValue.ToString();
    }
}
