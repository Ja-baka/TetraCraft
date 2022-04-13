using UnityEngine;
public class ActiveTetramino : MonoBehaviour
{
    private Shape _shape;
    private BlockMaterial _material;

    public Shape Shape => _shape;
    public BlockMaterial Material => _material;

    public void Init(Shape shape, BlockMaterial material)
    {
        _shape = shape;
        _material = material;
    }

    private void Start()
    {
        Instantiate(_material.Model, transform);
    }
}
