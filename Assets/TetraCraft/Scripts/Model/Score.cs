using System;
using UnityEngine;

public class Score : IDisposable
{
    private const int LinesCountForSpeedUp = 10;
    private FieldEventLocator _locator;
    private Settings _settings;
    private int _clearedLinesCount;
    private int _scoreValue;
    private int _combo;

    public Score(FieldEventLocator locator, Settings settings)
    {
        _locator = locator;
        _settings = settings;

        _locator.LineCleared += OnLineCleared;
        _locator.TurnDoned += OnTurnDone;
        _locator.GameOvered += OnGameOvered;
    }

    private void OnGameOvered()
    {
        var newEntry = new HighscoreEntry("PlaceHolder", ScoreValue);
        var highscoresTable = new HighscoresTable();
        highscoresTable.TryAddNewScore(newEntry);
        highscoresTable.SaveTable();
    }

    public event Action ScoreUpdated;

    public int ScoreValue => _scoreValue;
    public int ClearedLinesCount => _clearedLinesCount;
    public int Level
        => _clearedLinesCount / LinesCountForSpeedUp + 1;

    public void Dispose()
    {
        _locator.LineCleared -= OnLineCleared;
        _locator.TurnDoned -= OnTurnDone;
    }

    private void OnLineCleared()
    {
        int oldLevel = Level;
        _combo++;

        _clearedLinesCount++;
        int lineCoast = (int)(Mathf.Pow(_combo, _settings.ComboScaller)
            * _settings.ScoreMultiplier);
        _scoreValue += lineCoast * Level;

        ScoreUpdated?.Invoke();
    }

    private void OnTurnDone()
    {
        _combo = 0;
    }

    [Serializable]
    public class Settings
    {
        public float ComboScaller;
        public int ScoreMultiplier;
    }
}
