using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeEditor;
using UnityEngine;

public class FieldCells
{
    private BlockMaterial[,] _cells;

    public BlockMaterial[,] CellsClone => _cells.Clone() as BlockMaterial[,];
    public BlockMaterial[,] Cells { get => _cells; set => _cells = value; }

    public FieldCells()
    {
        // https://tetris.fandom.com/wiki/Tetris_Guideline
        const int Width = 10;
        const int Heigth = 24;

        _cells = new BlockMaterial[Width, Heigth];
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
