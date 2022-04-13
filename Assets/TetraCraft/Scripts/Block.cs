public class Block
{
    private BlockMaterial _material;

    public Block(BlockMaterial material)
    {
        _material = material;
    }

    public BlockMaterial Material => _material;
}
