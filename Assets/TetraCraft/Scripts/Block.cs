using System;
using UnityEngine;

[Serializable]
public class Block
{
    public Vector2Int Position;
    private BlockMaterial _material;

    public Block(BlockMaterial material)
    {
        _material = material;
    }

    public BlockMaterial Material => _material;
}
