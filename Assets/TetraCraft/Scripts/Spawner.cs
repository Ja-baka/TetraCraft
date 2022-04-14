using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ShapeGenerator _shapeGenerator;
    [SerializeField] private MaterialGenerator _materialGenerator;
    [SerializeField] private ActiveTetramino _tetramino;

    private void Start()
    {
        Block[] shape = _shapeGenerator.PickRandomShape();
        BlockMaterial material = _materialGenerator.PickRandomMaterial();

        _tetramino.Init(shape, material);

        Instantiate(_tetramino, transform);
    }
}
