using System;
using System.Collections;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Tetramino _tetramino;
    [SerializeField] private float _timeToClearLine;

    private BlockMaterial[,] _cells;
    private Vector2Int[] _previousPositions;
    private bool _playing = true;

    public event Action<BlockMaterial[,]> Updated;
    public event Action LineCleared;

    public BlockMaterial[,] FieldView => (BlockMaterial[,])_cells.Clone();

    private void Awake()
    {
        _cells = InitializeArray();
    }

    private BlockMaterial[,] InitializeArray()
    {
        // https://tetris.fandom.com/wiki/Tetris_Guideline
        const int Width = 10;
        const int Heigth = 20;

        return new BlockMaterial[Width, Heigth];
    }

    private void OnEnable()
    {
        _spawner.TetraminoSpawned += OnTetraminoSpawned;
        _tetramino.TetraminoMoved += OnTetraminoMoved;
        _tetramino.Falled += () => StartCoroutine(OnTetraminoFalled());
    }

    private void OnDisable()
    {
        _spawner.TetraminoSpawned -= OnTetraminoSpawned;
        _tetramino.TetraminoMoved -= OnTetraminoMoved;
        _tetramino.Falled -= () => OnTetraminoFalled();
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

    private IEnumerator OnTetraminoFalled()
    {
        CalculatePhysics();
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
                yield return new WaitForSeconds(_timeToClearLine);
                yield return StartCoroutine(ClearLine(y--));
                Updated?.Invoke(FieldView);
            }
        }

        LineCleared?.Invoke();
    }

    private void CalculatePhysics()
    {
        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                if (_cells[x, y] == null)
                {
                    continue;
                }
                _cells[x, y].Weight
                    .Fall(new Vector2Int(x, y), ref _cells);
            }
        }
    }

    private IEnumerator ClearLine(int indexOfRow)
    {
        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            _cells[x, indexOfRow] = null;
        }

        Updated?.Invoke(FieldView);
        yield return new WaitForSeconds(_timeToClearLine);

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
