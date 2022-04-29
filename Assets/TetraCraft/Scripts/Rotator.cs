using System;
using System.Linq;
using UnityEngine;

public class Rotator
{
    private const int MaxTurn = 4;
    private const int InitialTurn = 1;
    private Vector2Int[] _positions;
    private int _currentTurn;
    private Vector2Int _minPositionOffset;

    public Rotator(Vector2Int[] positions)
    {
        _positions = positions;
        _currentTurn = InitialTurn;
    }

    public Vector2Int[] TryRotate()
    {
        NormalizePositions();
        AddOffset();
        Rotate();
        ScalePositions();
        ReversePositions();

        return _positions;
    }

    public Vector2Int[] GetRotated(Vector2Int[] positions)
    {
        Vector2Int[] rotated = (Vector2Int[])positions.Clone();
        rotated = Transpose(rotated);
        rotated = ReflectByY(rotated);
        return rotated;
    }

    private void NormalizePositions()
    {
        int minX = _positions.Min((p) => p.x);
        int minY = _positions.Min((p) => p.y);

        _minPositionOffset = new Vector2Int(minX, minY);
        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i] -= _minPositionOffset;
        }
    }

    private void AddOffset()
    {
        int maxX = _positions.Max((p) => p.x);
        int maxY = _positions.Max((p) => p.y);
        int max = Math.Max(maxX, maxY);
        Vector2Int turnOffset = GetOffsetByTurn(max);

        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i] += turnOffset;
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

    private void Rotate()
    {
        _currentTurn = _currentTurn == MaxTurn
            ? _currentTurn + 1
            : InitialTurn;

        _positions = GetRotated(_positions);
    }


    private Vector2Int[] ReflectByY(Vector2Int[] rotated)
    {
        int width = rotated.Max((p) => p.y) + 1;
        for (int i = 0; i < rotated.Length; i++)
        {
            rotated[i].y = width - rotated[i].y;
        }
        return rotated;
    }

    private Vector2Int[] Transpose(Vector2Int[] rotated)
    {
        for (int i = 0; i < rotated.Length; i++)
        {
            (rotated[i].x, rotated[i].y)
                = (rotated[i].y, rotated[i].x);
        }
        return rotated;
    }

    private void ScalePositions()
    {
        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i] += _minPositionOffset;
        }
    }

    private void ReversePositions()
    {
        _positions.Reverse();
    }
}
