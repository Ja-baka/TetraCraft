using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Score _scoreModel;
    [Space]
    [SerializeField] private TextMeshProUGUI _clearedLinesView;
    [SerializeField] private TextMeshProUGUI _levelView;
    [SerializeField] private TextMeshProUGUI _scoreValueView;

    private void OnEnable()
    {
        _scoreModel.ClearedLinesIncrement += OnClearedLinesIncrement;
    }

    private void OnDisable()
    {
        _scoreModel.ClearedLinesIncrement -= OnClearedLinesIncrement;
    }

    private void OnClearedLinesIncrement()
    {
        _clearedLinesView.text = _scoreModel.ClearedLinesCount.ToString();
        _levelView.text = _scoreModel.Level.ToString();
        _scoreValueView.text = _scoreModel.ScoreValue.ToString();
    }
}
