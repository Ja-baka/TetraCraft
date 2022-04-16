using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ActiveTetramino _tetramino;
    private BlockMaterial[,] _cells;
    private Vector2Int[] _tetraminoPosition;

    private void Awake()
    {
        _cells = FillArray();
    }

    private BlockMaterial[,] FillArray()
    {
        const int ClassicTetrisFieldWidth = 10;
        const int ClassicTetrisFieldHeigth = 20;
        BlockMaterial[,] array = new BlockMaterial
            [ClassicTetrisFieldWidth, ClassicTetrisFieldHeigth];

        return array;
    }

    private void OnEnable()
    {
        _spawner.TetraminoSpawned += OnTetraminoSpawned;
        _tetramino.Moved += OnTetraminoMoved;
        _tetramino.Falled += OnTetraminoFalled;
    }

    private void OnDisable()
    {
        _spawner.TetraminoSpawned -= OnTetraminoSpawned;
        _tetramino.Moved -= OnTetraminoMoved;
        _tetramino.Falled -= OnTetraminoFalled;
    }

    public void OnTetraminoSpawned(ActiveTetramino tetramino)
    {
        _tetraminoPosition = new Vector2Int[4];
        int i = 0;
        foreach (Block block in tetramino.Blocks)
        {
            int x = block.Position.x;
            int y = block.Position.y;

            if ((_cells[x, y] is null) == false)
            {
                GameOver();
            }

            _cells[x, y] = block.Material;
            _tetraminoPosition[i++] = block.Position;
        }
    }

    private void OnTetraminoFalled()
    {
        for (int y = 0; y < _cells.GetLength(1); y++)
        {
            bool isFullRow = true;
            for (int x = 0; x < _cells.GetLength(0); x++)
            {
                if (_cells[x, y] is null)
                {
                    isFullRow = false;
                    break;
                }
            }
            if (isFullRow)
            {
                ClearLine(y);
            }
        }
    }

    private void OnTetraminoMoved(Vector2Int offset)
    {
        foreach (Vector2Int oldPosition in _tetraminoPosition)
        {
            Vector2Int newPosition = oldPosition + offset;

            (_cells[oldPosition.x, oldPosition.y], _cells[newPosition.x, newPosition.y])
                = (_cells[newPosition.x, newPosition.y], _cells[oldPosition.x, oldPosition.y]);
        }
    }

    public void ClearLine(int indexOfRow)
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

    public bool IsCanFall(Shape shape)
    {
        //return shape.Positions.Any((p) => _cells[p.x, p.y - 1] != null);
        foreach (Vector2Int position in shape.Positions)
        {
            Vector2Int bellow = position + Vector2Int.down;
            if (bellow.y == 0
                || _tetraminoPosition.Contains(bellow) == false
                && _cells[bellow.x, bellow.y] != null)
            {
                return false;
            }
        }
        return true;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Application.Quit();
    }
}
