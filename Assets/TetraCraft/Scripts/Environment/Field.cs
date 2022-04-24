using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Field : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Tetramino _tetramino;
    private BlockMaterial[,] _cells;
    private Vector2Int[] _previousPositions;
    private bool _playing = true;

    public event Action<BlockMaterial[,]> Updated;

    public BlockMaterial[,] FieldView => (BlockMaterial[,])_cells.Clone();

    private void Awake()
    {
        _cells = InitializeArray();
    }

    private BlockMaterial[,] InitializeArray()
    {
        const int ClassicWidth = 10;
        const int ClassicHeigth = 20;

        return new BlockMaterial[ClassicWidth, ClassicHeigth];
    }

    private void OnEnable()
    {
        _spawner.TetraminoSpawned += OnTetraminoSpawned;
        _tetramino.TetraminoMoved += OnTetraminoMoved;
        _tetramino.Falled += OnTetraminoFalled;
    }

    private void OnDisable()
    {
        _spawner.TetraminoSpawned -= OnTetraminoSpawned;
        _tetramino.TetraminoMoved -= OnTetraminoMoved;
        _tetramino.Falled -= OnTetraminoFalled;
    }

    public void OnTetraminoSpawned(Tetramino tetramino)
    {
        _previousPositions = (Vector2Int[])tetramino.Positions.Clone();
        foreach (Vector2Int block in tetramino.Positions)
        {
            int x = block.x;
            int y = block.y;

            if (_cells[x, y] != null)
            {
                GameOver();
            }

            _cells[x, y] = tetramino.Material;
        }
        Updated?.Invoke(FieldView);
}

    public bool TetraminoCanRotate()
    {
        throw new NotImplementedException();
    }

    public bool TetraminoCanFall()
    {
        return TetraminoCanMove(Vector2Int.down,
           (position) => position.y == 0);
    }

    public bool TetraminoCanMoveLeft()
    {
        return TetraminoCanMove(Vector2Int.left,
            (position) => position.x == 0);
    }

    public bool TetraminoCanMoveRight()
    {
        return TetraminoCanMove(Vector2Int.right, 
            (position) => position.x == _cells.GetLength(0) - 1);
    }

    public bool TetraminoCanMove(Vector2Int direction, 
        Predicate<Vector2Int> blockOutOfFiled)
    {
        foreach (Vector2Int position in _tetramino.Positions)
        {
            Vector2Int offsetted = position + direction;

            if (blockOutOfFiled(position) 
                || AlreadyOccupied(offsetted))
            {
                return false;
            }
        }
        return true;

        bool AlreadyOccupied(Vector2Int offsetted) 
            => _tetramino.Positions.Contains(offsetted) == false
                && _cells[offsetted.x, offsetted.y] != null;
    }

    private void GameOver()
    {
        if (_playing == false)
        {
            return;
        }
        _playing = false;

        Debug.Log("Game Over");
        Application.Quit();

        Time.timeScale = 0;
    }

    private void OnTetraminoMoved()
    {
        foreach (Vector2Int position in _previousPositions)
        {
            _cells[position.x, position.y] = null;
        }

        foreach (Vector2Int position in _tetramino.Positions)
        {
            _cells[position.x, position.y] = _tetramino.Material;
        }

        Updated?.Invoke(FieldView);
        _previousPositions = (Vector2Int[])_tetramino.Positions.Clone();
    }

    private void OnTetraminoFalled()
    {
        for (int y = 0; y < _cells.GetLength(1); y++)
        {
            bool isFullRow = true;
            for (int x = 0; x < _cells.GetLength(0); x++)
            {
                if (_cells[x, y] == null)
                {
                    isFullRow = false;
                    break;
                }
            }
            if (isFullRow)
            {
                ClearLine(y--);
            }
        }
        Updated?.Invoke(FieldView);
    }
    
    private void ClearLine(int indexOfRow)
    {
        for (int y = indexOfRow; y < _cells.GetLength(1) - 1; y++)
        {
            for (int x = 0; x < _cells.GetLength(0); x++)
            {
                _cells[x, y] = _cells[x, y + 1];
            }
        }
        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            _cells[x, _cells.GetLength(1) - 1] = null;
        }
    }
}
