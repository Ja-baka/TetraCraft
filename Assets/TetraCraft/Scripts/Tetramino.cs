﻿using System;
using System.Linq;
using UnityEngine;

public class Tetramino : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Field _field;

    private Vector2Int[] _positions;
    private BlockMaterial _material;
    private Rotator _rotator;

    public void Init(Shape shape, BlockMaterial material)
    {
        _material = material;
        Vector2Int spawnerPosition = new Vector2Int(3, 17);
        
        _positions = new Vector2Int[4];
        for (int i = 0; i < _positions.Length; i++)
        {
            Vector2Int position = shape.Positions[i] + spawnerPosition;
            _positions[i] = position;
        }

        _rotator = new Rotator(_positions);
    }

    public event Action Falled;
    public event Action TetraminoMoved;

    public Vector2Int[] Positions => _positions;
    public BlockMaterial Material => _material;

    public void TryRotate()
    {
        _positions = _rotator.TryRotate();
        TetraminoMoved?.Invoke();
    }

    public void TryMoveLeft()
    {
        TryMove(IsCanMoveLeft(),
            () =>
            {
                for (int i = 0; i < _positions.Length; i++)
                {
                    _positions[i].x--;
                }
            });
    }

    public void TryMoveRight()
    {
        TryMove(ISCanMoveRight(),
            () =>
            {
                for (int i = 0; i < _positions.Length; i++)
                {
                    _positions[i].x++;
                }
            });
    }

    private void OnEnable()
    {
        _timer.Tick += TryFall;
    }

    private void OnDisable()
    {
        _timer.Tick -= TryFall;
    }

    private bool IsCanFall()
    {
        return IsCanMove((p) => p + Vector2Int.down,
           (position) => position.y == 0);
    }

    private bool IsCanMoveLeft()
    {
        return IsCanMove((p) => p + Vector2Int.left,
            (position) => position.x == 0);
    }

    private bool ISCanMoveRight()
    {
        return IsCanMove((p) => p + Vector2Int.right,
            (position) => position.x == _field.FieldView.GetLength(0) - 1);
    }

    private bool IsCanMove(Func<Vector2Int, Vector2Int> move,
        Predicate<Vector2Int> positionOnBorder)
    {
        foreach (Vector2Int position in _positions)
        {
            Vector2Int offsetted = move(position);

            if (positionOnBorder(position)
                || AlreadyOccupied(offsetted))
            {
                return false;
            }
        }
        return true;

        bool AlreadyOccupied(Vector2Int offsetted)
            => _positions.Contains(offsetted) == false
                && _field.FieldView[offsetted.x, offsetted.y] != null;
    }

    private void TryFall()
    {
        if (IsCanFall() == false)
        {
            ReachBottom();
            return;
        }

        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i].y--;
        }
        TetraminoMoved?.Invoke();
    }

    private void TryMove(bool isCan, Action move)
    {
        if (isCan == false)
        {
            return;
        }

        move();
        TetraminoMoved?.Invoke();
    }

    private void ReachBottom()
    {
        Falled?.Invoke();
        _timer.EndBoost();
    }
}
