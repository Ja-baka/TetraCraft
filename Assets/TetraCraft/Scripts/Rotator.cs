using System;
using System.Linq;
using UnityEngine;

public class Rotator
{
    private const int MaxTurn = 4;
    private const int InitialTurn = 1;

    private readonly Vector2Int[] _positions;
    private Vector2Int[] _normalized;

    private int _currentTurn;
    private Vector2Int _minPositionOffset;

    public Rotator(Vector2Int[] positions)
    {
        _positions = positions;
        _currentTurn = InitialTurn;
    }

    public Vector2Int[] GetRotated()
    {
        _normalized = (Vector2Int[])_positions.Clone();

        NormalizePositions();
        DirectlyRotate();
        ScalePositions();
        ReversePositions();

        return _normalized;
    }

    public void NextTurn()
    {
        _currentTurn = _currentTurn != MaxTurn
            ? _currentTurn + 1
            : InitialTurn;
    }

    private void NormalizePositions()
    {
        int minX = _normalized.Min((p) => p.x);
        int minY = _normalized.Min((p) => p.y);

        _minPositionOffset = new Vector2Int(minX, minY);

        for (int i = 0; i < _normalized.Length; i++)
        {
            _normalized[i] -= _minPositionOffset;
        }
    }

    private void DirectlyRotate()
    {
        Transpose();
        ReflectByY();
    }

    private void ReflectByY()
    {
        int width = _normalized.Max((p) => p.y)/* + 1*/;
        for (int i = 0; i < _normalized.Length; i++)
        {
            _normalized[i].y = width - _normalized[i].y;
        }
    }

    private void Transpose()
    {
        for (int i = 0; i < _normalized.Length; i++)
        {
            (_normalized[i].x, _normalized[i].y)
                = (_normalized[i].y, _normalized[i].x);
        }
    }

    private void ScalePositions()
    {
        for (int i = 0; i < _normalized.Length; i++)
        {
            _normalized[i] += _minPositionOffset;
        }
    }

    private void ReversePositions()
    {
        _normalized.Reverse();
    }
}
