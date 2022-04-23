using System;
using System.Linq;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ActiveTetramino _tetramino;
    private BlockMaterial[,] _cells;
    private Vector2Int[] _figurePosition;
    private bool _playing = true;

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

    public bool IsCanMoveLeft(Block[] blocks)
    {
        foreach (Block block in blocks)
        {
            Vector2Int leftward = block.Position + Vector2Int.left;
            if (block.Position.x == 0
                || _figurePosition.Contains(leftward) == false
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
                || _figurePosition.Contains(rightward) == false
                && _cells[rightward.x, rightward.y] != null)
            {
                return false;
            }
        }
        return true;
    }

    public void OnTetraminoSpawned(ActiveTetramino tetramino)
    {
        _figurePosition = new Vector2Int[4];
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
            _figurePosition[i++] = block.Position;
        }
        Updated?.Invoke(Cells);
    }

    public void ClearLine(int indexOfRow)
    {
        Debug.Log($"Clear Line {indexOfRow}");
    }

    public bool IsCanFall(Block[] blocks)
    {
        foreach (Block block in blocks)
        {
            Vector2Int bellow = block.Position + Vector2Int.down;
            if (block.Position.y == 0
                || _figurePosition.Contains(bellow) == false
                && _cells[bellow.x, bellow.y] != null)
            {
                return false;
            }
        }
        return true;
    }

    public void GameOver()
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

    private void OnTetraminoMoved(Vector2Int offset)
    {
        Vector2Int[] oldPositions = (Vector2Int[])_figurePosition.Clone();

        for (int i = 0; i < _tetramino.Blocks.Length; i++)
        {
            _cells[_figurePosition[i].x, _figurePosition[i].y] = null;
        }
        for (int i = 0; i < _tetramino.Blocks.Length; i++)
        {
            _figurePosition[i] += offset;
        }
        for (int i = 0; i < _tetramino.Blocks.Length; i++)
        {
            _cells[_figurePosition[i].x, _figurePosition[i].y] 
                = _tetramino.Blocks[i].Material;
        }
        Updated?.Invoke(Cells);
    }

    private void SwapCells(ref Vector2Int first, ref Vector2Int second)
    {
        (_cells[second.x, second.y], _cells[first.x, first.y])
            = (_cells[first.x, first.y], _cells[second.x, second.y]); 
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
}
