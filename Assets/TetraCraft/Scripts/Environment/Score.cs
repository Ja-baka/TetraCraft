using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    private const int LinesCountForSpeedUp = 10;

    [SerializeField] private Field _field;

    private int _clearedLinesCount = 0;
    private int _scoreValue = 0;

    public event Action ScoreUpdated;

    public int ScoreValue => _scoreValue;
    public int ClearedLinesCount => _clearedLinesCount;
    public int Level 
        => _clearedLinesCount / LinesCountForSpeedUp + 1;

    private void OnEnable()
    {
        _field.LineCleared += OnLineCleared;
    }

    private void OnDisable()
    {
        _field.LineCleared -= OnLineCleared;
    }

    private void OnLineCleared()
    {
        int oldLevel = Level;

        _clearedLinesCount++;
        _scoreValue += 40 * Level;

        ScoreUpdated?.Invoke();
    }
}
