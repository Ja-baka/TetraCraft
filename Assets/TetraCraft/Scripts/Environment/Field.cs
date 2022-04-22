using System;
using System.Linq;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ActiveTetramino _tetramino;
    private BlockMaterial[,] _cells;
    private Vector2Int[] _tetraminoPosition;
    private bool _playing = true;

    public BlockMaterial[,] Cells => _cells;
    public event Action Updated;

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
        Updated?.Invoke();
    }

    private void OnTetraminoMoved(Vector2Int offset)
    {
        for (int i = 0; i < _tetramino.Blocks.Length; i++)
        {
            Vector2Int oldPosition = _tetraminoPosition[i];
            Vector2Int newPosition = oldPosition + offset;

            (_cells[newPosition.x, newPosition.y], _cells[oldPosition.x, oldPosition.y])
                = (_cells[oldPosition.x, oldPosition.y], _cells[newPosition.x, newPosition.y]);

            _tetraminoPosition[i] += offset;
        }
        Updated?.Invoke();
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
        Updated?.Invoke();
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
        if (_playing == false)
        {
            return;
        }
        _playing = false;

        Debug.Log("Game Over");
        Application.Quit();

        Time.timeScale = 0;
    }
}
