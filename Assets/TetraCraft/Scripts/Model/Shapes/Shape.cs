using System;

public abstract class Shape
{
    protected const bool O = false;
    protected const bool I = true;
    private int _indexOfCurrent;

    protected Shape()
    {
        _rotates = new bool[4][,];

        _rotates[0] = CreateRotate1();
        _rotates[1] = CreateRotate2();
        _rotates[2] = CreateRotate3();
        _rotates[3] = CreateRotate4();

        if (TetraminoValidator.Validate(_rotates) == false)
        {
            throw new InvalidOperationException($"Тэтраміно {GetType().Name} складаецца не з {TetraminoValidator.ExpectedBlocksCount}-х блокаў");
        }
    }

    protected abstract bool[,] CreateRotate1();
    protected abstract bool[,] CreateRotate2();
    protected abstract bool[,] CreateRotate3();
    protected abstract bool[,] CreateRotate4();

    public bool[,] Current => _rotates[_indexOfCurrent];
    public bool[,] Next => _rotates[(_indexOfCurrent + 1) % 4];
    private bool[][,] _rotates { get; }

    public void Rotate()
    {
        _indexOfCurrent++;
        _indexOfCurrent %= 4;
    }
}
