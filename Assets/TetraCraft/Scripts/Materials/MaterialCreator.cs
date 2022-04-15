using UnityEngine;

public class MaterialCreator : Creator<BlockMaterial>
{
    [SerializeField] private BlockMaterial[] _materials;

    protected override BlockMaterial[] FillArray()
    {
        return _materials;
    }
}
