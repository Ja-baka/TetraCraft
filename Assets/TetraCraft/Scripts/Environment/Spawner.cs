using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Tetramino _tetramino;
    [SerializeField] private MaterialCreator _materialCreator;
    [SerializeField] private ShapeCreator _shapeCreator;
    [SerializeField] private Field _field;

    public event Action<Tetramino> TetraminoSpawned;

    private void Start()
    {
        Spawn();
    }

    private void OnEnable()
    {
        _field.TurnEnded += Spawn;
    }

    private void OnDisable()
    {
        _field.TurnEnded -= Spawn;
    }

    public void Spawn()
    {
        BlockMaterial material = _materialCreator.PickRandom();
        Shape shape = Instantiate(_shapeCreator.PickRandom());

        _tetramino.Init(shape, material);

        TetraminoSpawned?.Invoke(_tetramino);
    }
}
