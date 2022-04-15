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
        if (_position.y == 0)
        {
            throw new System.InvalidOperationException();
        }
        _position.y--;
    }
}
