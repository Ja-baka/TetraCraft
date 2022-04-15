using UnityEngine;

[CreateAssetMenu(menuName = "SO/BlockMaterial", fileName = "New Block Material")]
public class BlockMaterial : ScriptableObject
{
    [SerializeField] private Material _material;

    public Material Material => _material;
}
