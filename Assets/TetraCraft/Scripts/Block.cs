using UnityEngine;

public class Block
{
    private Vector2Int _position;
    private BlockMaterial _material;

    public Block(Vector2Int position, BlockMaterial material)
    {
        _position = position;
        _material = material;
    }

    public Vector2Int Position => _position;
    public BlockMaterial Material => _material;

    public void Fall()
    {
        if (IsCanFall() == false)
        {
            throw new System.InvalidOperationException("Блёк упаў");
        }
        _position.y--;
    }

    public bool IsCanFall()
    {
        return _position.y != 0;
    }
}
