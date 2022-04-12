using System;
using UnityEngine;

public abstract class Shape
{
    private int _indexOfCurrent;
    private Vector2Int[][] _rotates;


    protected Shape()
    {
        _rotates = new Vector2Int[4][];

        CreateRotate1(out _rotates[0]);
        CreateRotate2(out _rotates[1]);
        CreateRotate3(out _rotates[2]);
        CreateRotate4(out _rotates[3]);

        if (TetraminoValidator.Validate(_rotates) == false)
        {
            throw new InvalidOperationException($"Тэтраміно {GetType().Name} складаецца не з {TetraminoValidator.ExpectedBlocksCount}-х блокаў");
        }
    }

    protected abstract void CreateRotate1(out Vector2Int[] rotate);
    protected abstract void CreateRotate2(out Vector2Int[] rotate);
    protected abstract void CreateRotate3(out Vector2Int[] rotate);
    protected abstract void CreateRotate4(out Vector2Int[] rotate);

    public Vector2Int[] Current => _rotates[_indexOfCurrent];
    public Vector2Int[] Next => _rotates[(_indexOfCurrent + 1) % 4];

    public void Rotate()
    {
        _indexOfCurrent++;
        _indexOfCurrent %= 4;
    }
}
