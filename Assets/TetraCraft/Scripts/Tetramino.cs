using UnityEngine;
public class Tetramino : MonoBehaviour
{
    private Shape _shape;
    private Material _material;

    public Shape Shape => _shape;
    public Material Material => _material;

    public void Initialize(Shape shape, Material material)
    {
        _shape = shape;
        _material = material;
    }

    private void Start()
    {
        Instantiate(_material.Model, transform);
    }
}
