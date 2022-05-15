using UnityEngine;

public class FieldCells
{
    private BlockMaterial[,] _cells;

    public BlockMaterial[,] CellsClone => _cells.Clone() as BlockMaterial[,];
    public BlockMaterial[,] Cells { get => _cells; set => _cells = value; }

    public FieldCells()
    {
        int width = Constants.FieldWidth;
        int heigth = Constants.FieldHeigth;

        _cells = new BlockMaterial[width, heigth];
    }

    public BlockMaterial this[Vector2Int index]
    {
        get => _cells[index.x, index.y];
        set => _cells[index.x, index.y] = value;
    }

    public BlockMaterial this[int x, int y]
    {
        get => _cells[x, y];
        set => _cells[x, y] = value;
    }

    internal int GetLength(int dimension)
    {
        return _cells.GetLength(dimension);
    }
}
