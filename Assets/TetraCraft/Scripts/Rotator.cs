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

    public Vector2Int[] Rotate()
    {
        _normalized = (Vector2Int[])_positions.Clone();
        NormalizePositions();
        AddOffset();
        DirectlyRotate();
        ScalePositions();
        ReversePositions();

        return _normalized;
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

    private void AddOffset()
    {
        int maxX = _normalized.Max((p) => p.x);
        int maxY = _normalized.Max((p) => p.y);
        int max = Math.Max(maxX, maxY);
        Vector2Int turnOffset = GetOffsetByTurn(max);

        for (int i = 0; i < _normalized.Length; i++)
        {
            _normalized[i] += turnOffset;
        }
        _minPositionOffset -= turnOffset;
    }

    private Vector2Int GetOffsetByTurn(int maxXY)
    {
        Vector2Int turnOffset = new Vector2Int();

        if (_currentTurn == 1)
        {
            turnOffset.y = maxXY - 1;
        }
        else if (_currentTurn == 2)
        {
            turnOffset.x = maxXY - 1;
        }
        else if (_currentTurn == 3)
        {
            turnOffset.y = maxXY - 2;
        }
        else if (_currentTurn == 4)
        {
            turnOffset.x = maxXY - 2;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(_currentTurn));
        }

        return turnOffset;
    }

    private void DirectlyRotate()
    {
        _currentTurn = _currentTurn == MaxTurn
            ? _currentTurn + 1
            : InitialTurn;

        _normalized = Transpose();
        _normalized = ReflectByY();
    }

    private Vector2Int[] ReflectByY()
    {
        int width = _normalized.Max((p) => p.y) + 1;
        for (int i = 0; i < _normalized.Length; i++)
        {
            _normalized[i].y = width - _normalized[i].y;
        }
        return _normalized;
    }

    private Vector2Int[] Transpose()
    {
        for (int i = 0; i < _normalized.Length; i++)
        {
            (_normalized[i].x, _normalized[i].y)
                = (_normalized[i].y, _normalized[i].x);
        }
        return _normalized;
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
