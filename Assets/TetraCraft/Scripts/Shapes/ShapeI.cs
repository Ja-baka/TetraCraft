using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Shapes/I", fileName = "ShapeI")]
public class ShapeI : Shape
{
    [SerializeField] private Block[] _blocks;

    public override Block[] Blocks => _blocks;
}
