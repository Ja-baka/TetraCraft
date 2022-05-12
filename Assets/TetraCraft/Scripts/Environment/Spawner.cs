using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Tetramino _tetramino;
    [SerializeField] private Creator _creator;
    [SerializeField] private Field _field;

    public event Action TetraminoSpawned;

    private void Start()
    {
        Spawn();
    }

    private void OnEnable()
    {
        _field.TurnDone += Spawn;
    }

    private void OnDisable()
    {
        _field.TurnDone -= Spawn;
    }

    public void Spawn()
    {
        BlockMaterial material = _creator.PickRandomMaterial();
        Shape shape = Instantiate(_creator.PickRandomShape());

        _tetramino.Init(shape, material);

        TetraminoSpawned?.Invoke();
    }
}
