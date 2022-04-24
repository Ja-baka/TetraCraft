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

    public bool IsCanRotate()
    {
        throw new NotImplementedException();
    }


    public bool IsCanFall(Vector2Int[] blocks)
    {
        foreach (Vector2Int block in blocks)
        {
            Vector2Int bellow = block + Vector2Int.down;
            if (block.y == 0
                || _tetramino.Positions.Contains(bellow) == false
                && _cells[bellow.x, bellow.y] != null)
            {
                return false;
            }
        }
        return true;
    }

    public bool IsCanMoveLeft(Vector2Int[] blocks)
    {
        foreach (Vector2Int block in blocks)
        {
            Vector2Int leftward = block + Vector2Int.left;
            if (block.x == 0
                || _tetramino.Positions.Contains(leftward) == false
                && _cells[leftward.x, leftward.y] != null)
            {
                return false;
            }
        }
        return true;
    }

    public bool IsCanMoveRight(Vector2Int[] blocks)
    {
        foreach (Vector2Int block in blocks)
        {
            Vector2Int rightward = block + Vector2Int.right;
            if (block.x == _cells.GetLength(0) - 1
                || _tetramino.Positions.Contains(rightward) == false
                && _cells[rightward.x, rightward.y] != null)
            {
                return false;
            }
        }
        return true;
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
        for (int i = 0; i < _tetramino.Positions.Length; i++)
        {
            _cells[_previousPositions[i].x, _previousPositions[i].y] = null;
        }

        for (int i = 0; i < _tetramino.Positions.Length; i++)
        {
            _cells[_tetramino.Positions[i].x, _tetramino.Positions[i].y] 
                = _tetramino.Material;
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
