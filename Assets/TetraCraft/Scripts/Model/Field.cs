using System;
using System.Collections;
using UnityEngine;

public class Field : IDisposable
{
    private Timer _timer;
    private Spawner _spawner;
    private Tetramino _tetramino;
    private Vector2Int[] _previousPositions;
    private WaitForSeconds _waitForDelay;
    private FieldCells _cells;
    private FieldEventLocator _locator;

    public Field(FieldEventLocator locator, FieldCells cells, 
        Timer timer, Spawner spawner, Tetramino tetramino)
    {
        _locator = locator; 
        _timer = timer;
        _spawner = spawner;
        _tetramino = tetramino;
        _cells = cells;

        _waitForDelay = new WaitForSeconds(_timer.AnimationTick);

        _spawner.TetraminoSpawned += OnTetraminoSpawned;
        _tetramino.TetraminoMoved += OnTetraminoMoved;
        _tetramino.Falled += OnTetraminoFalled;
    }

    public void Dispose()
    {
        _spawner.TetraminoSpawned -= OnTetraminoSpawned;
        _tetramino.TetraminoMoved -= OnTetraminoMoved;
        _tetramino.Falled -= OnTetraminoFalled;
    }

    public void OnTetraminoSpawned()
    {
        _previousPositions = (Vector2Int[])_tetramino.Positions.Clone();
        foreach (Vector2Int block in _tetramino.Positions)
        {
            if (_cells[block] != null)
            {
                Debug.Log("TryGameOver");
                _locator.TryGameOver();
                break;
            }

            _cells[block] = _tetramino.Material;
        }
        _locator.Update(_cells.CellsClone);
    }

    private void OnTetraminoMoved()
    {
        foreach (Vector2Int position in _previousPositions)
        {
            _cells[position] = null;
        }

        foreach (Vector2Int position in _tetramino.Positions)
        {
            _cells[position] = _tetramino.Material;
        }

        _locator.Update(_cells.CellsClone);
        _previousPositions = (Vector2Int[])_tetramino.Positions.Clone();
    }

    private void OnTetraminoFalled()
    {
        Coroutines.StartRoutine(EndTurn());
    }

    private IEnumerator EndTurn()
    {
        bool isAfterCleaning = false;
        for (int i = 0; i < 2; i++)
        {
            yield return CalculatePhysics(isAfterCleaning);
            yield return ClearLines();
            isAfterCleaning = true;
        }

        _locator.TurnDone();
    }

    private IEnumerator CalculatePhysics(bool isAfterCleaning)
    {
        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                if (_cells[x, y] == null)
                {
                    continue;
                }

                IWeight weight = _cells[x, y].Weight;
                BlockMaterial[,] temp = _cells.Cells;
                weight.Fall(new Vector2Int(x, y), ref temp, isAfterCleaning);
                _cells.Cells = temp;
            }
        }
        _locator.Update(_cells.CellsClone);
        yield return _waitForDelay;
    }

    private IEnumerator ClearLines()
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
                yield return _waitForDelay;
                yield return ClearLine(y--);
                _locator.LineClear();
                _locator.Update(_cells.CellsClone);
            }
        }
    }

    private IEnumerator ClearLine(int indexOfRow)
    {
        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            _cells[x, indexOfRow] = null;
        }

        _locator.Update(_cells.CellsClone);
        yield return _waitForDelay;

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
