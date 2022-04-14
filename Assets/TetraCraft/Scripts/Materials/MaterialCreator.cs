public class MaterialCreator : Creator<BlockMaterial>
{
    protected override BlockMaterial[] FillArray()
    {
        return new BlockMaterial[]
        {
            new Wool(),
        };
    }
}
