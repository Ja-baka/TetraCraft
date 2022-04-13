using System.Collections.Generic;
using UnityEngine;

public class BlockMaterialPicker : MonoBehaviour
{
    [SerializeField] private List<BlockMaterial> _materials;

    public BlockMaterial PickRandomMaterial()
    {
        int randomNumber = Random.Range(0, _materials.Count);
        return _materials[randomNumber];
    }
}