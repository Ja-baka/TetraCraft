using UnityEngine;

public class ScoreSaver : MonoBehaviour
{
    private Score _score;
    private int _scoreValue;
    private string _nickname;

    public void Construct(Score score)
    {
        _score = score;
        _score.ScoreUpdated += OnScoreUpdated;
        _score.GameOver += () => Unsubscribe();
    }
    private void Unsubscribe()
    {
        _score.ScoreUpdated -= OnScoreUpdated;
        _score.GameOver -= () => Unsubscribe();
    }

    private void OnScoreUpdated()
    {
        _scoreValue = _score.ScoreValue;
        _nickname = "PlaceHolder";
    }

    public string Nickname => _nickname;
    public int ScoreVale => _scoreValue;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
