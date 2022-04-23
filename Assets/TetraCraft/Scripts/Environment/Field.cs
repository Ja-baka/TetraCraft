using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Field : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ActiveTetramino _tetramino;
    private BlockMaterial[,] _cells;
    private bool _playing = true;
    private Vector2Int[] _activeTetraminoPosition;

    public event Action<BlockMaterial[,]> Updated;

    public BlockMaterial[,] Cells => (BlockMaterial[,])_cells.Clone();

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
    public void OnTetraminoSpawned(ActiveTetramino tetramino)
    {
        _activeTetraminoPosition = new Vector2Int[4];
        int i = 0;

        foreach (Block block in tetramino.Blocks)
        {
            int x = block.Position.x;
            int y = block.Position.y;

            if (_cells[x, y] != null)
            {
                GameOver();
            }

            _cells[x, y] = block.Material;
            _activeTetraminoPosition[i++] = block.Position;
        }
        Updated?.Invoke(Cells);
}

    public bool IsCanRotate()
    {
        Vector2Int[] rotated = _tetramino.GetRotated(_activeTetraminoPosition);

        foreach (Vector2Int position in rotated)
        {
            bool blockOutOfField = position.x < 0 
                || position.x >= _cells.GetLength(0)
                || position.y < 0 
                || position.y >= _cells.GetLength(1);
            bool alreadyOccupired = _activeTetraminoPosition
                .Contains(position) == false
                && _cells[position.x, position.y] != null;

            if (blockOutOfField || alreadyOccupired)
            {
                return false;
            }
        }

        return true;
    }


    public bool IsCanFall(Block[] blocks)
    {
        foreach (Block block in blocks)
        {
            Vector2Int bellow = block.Position + Vector2Int.down;
            if (block.Position.y == 0
                || _activeTetraminoPosition.Contains(bellow) == false
                && _cells[bellow.x, bellow.y] != null)
            {
                return false;
            }
        }
        return true;
    }

    public bool IsCanMoveLeft(Block[] blocks)
    {
        foreach (Block block in blocks)
        {
            Vector2Int leftward = block.Position + Vector2Int.left;
            if (block.Position.x == 0
                || _activeTetraminoPosition.Contains(leftward) == false
                && _cells[leftward.x, leftward.y] != null)
            {
                return false;
            }
        }
        return true;
    }

    public bool IsCanMoveRight(Block[] blocks)
    {
        foreach (Block block in blocks)
        {
            Vector2Int rightward = block.Position + Vector2Int.right;
            if (block.Position.x == _cells.GetLength(0) - 1
                || _activeTetraminoPosition.Contains(rightward) == false
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

    private void OnTetraminoMoved(Block[] blocks)
    {
        Vector2Int[] oldPositions = (Vector2Int[])_activeTetraminoPosition.Clone();

        for (int i = 0; i < _tetramino.Blocks.Length; i++)
        {
            _cells[_activeTetraminoPosition[i].x, _activeTetraminoPosition[i].y] = null;
        }
        for (int i = 0; i < _tetramino.Blocks.Length; i++)
        {
            _activeTetraminoPosition[i] = blocks[i].Position;
        }
        for (int i = 0; i < _tetramino.Blocks.Length; i++)
        {
            _cells[_activeTetraminoPosition[i].x, _activeTetraminoPosition[i].y] 
                = _tetramino.Blocks[i].Material;
        }
        Updated?.Invoke(Cells);
    }

    private void OnTetraminoFalled(GameObject[] cubes)
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
        Updated?.Invoke(Cells);
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
