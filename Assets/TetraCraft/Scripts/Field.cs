using System;
using System.Linq;
using System.Text;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ActiveTetramino _tetramino;
    private BlockMaterial[,] _cells;
    private Vector2Int[] _tetraminoPosition;

    private void Awake()
    {
        _cells = InitializeArray();
    }

    private BlockMaterial[,] InitializeArray()
    {
        const int ClassicTetrisFieldWidth = 10;
        const int ClassicTetrisFieldHeigth = 20;

        return new BlockMaterial
            [ClassicTetrisFieldWidth, ClassicTetrisFieldHeigth];
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
        _tetraminoPosition = new Vector2Int[4];
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
            _tetraminoPosition[i++] = block.Position;
        }
        // DrawField();
    }

    private void OnTetraminoMoved(Vector2Int offset)
    {
        if (_tetraminoPosition.Any((p) => p.y == 0))
        {
            //return;
        }

        for (int i = 0; i < _tetramino.Blocks.Length; i++)
        {
            Vector2Int oldPosition = _tetraminoPosition[i];
            Vector2Int newPosition = oldPosition + offset;

            (_cells[newPosition.x, newPosition.y], _cells[oldPosition.x, oldPosition.y])
                = (_cells[oldPosition.x, oldPosition.y], _cells[newPosition.x, newPosition.y]);

            _tetraminoPosition[i] += offset;
        }
        // DrawField();
    }

    private void DrawField()
    {
        StringBuilder sb = new StringBuilder();
        for (int y = 0; y < _cells.GetLength(1); y++)
        {
            for (int x = 0; x < _cells.GetLength(0); x++)
            {
                sb.Append(_cells[x, _cells.GetLength(1) - 1 - y] == null ? "░░" : "██");
            }
            sb.AppendLine();
        }
        Debug.Log(sb.ToString());
    }

    private void OnTetraminoFalled(GameObject[] cubes)
    {
        // DrawField();
        Array.ForEach(cubes, (c) => c.transform.SetParent(transform, false));

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
    }

    public void ClearLine(int indexOfRow)
    {
        Debug.Log("Clear Line");
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

    public bool IsCanFall(Block[] blocks)
    {
        foreach (Block block in blocks)
        {
            Vector2Int bellow = block.Position + Vector2Int.down;
            if (block.Position.y == 0
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
