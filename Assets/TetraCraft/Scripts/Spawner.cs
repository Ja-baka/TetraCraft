using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ActiveTetramino _activeTetramino;
    [SerializeField] private MaterialCreator _materialCreator;
    [SerializeField] private ShapeCreator _shapeCreator;

    public event Action<ActiveTetramino> TetraminoSpawned;

    private void Start()
    {
        Spawn();
    }

    private void OnEnable()
    {
        _activeTetramino.Falled += Spawn;
    }

    private void OnDisable()
    {
        _activeTetramino.Falled -= Spawn;
    }

    public void Spawn()
    {
        BlockMaterial material = _materialCreator.PickRandom();
        Shape shape = Instantiate(_shapeCreator.PickRandom());

        _activeTetramino.Init(shape, material);

        TetraminoSpawned?.Invoke(_activeTetramino);
    }
}
