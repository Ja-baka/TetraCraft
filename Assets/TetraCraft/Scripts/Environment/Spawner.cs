using System;
using UnityEngine;
using Zenject;

public class Spawner : IDisposable
{
    private Creator _creator;
    private FieldEventLocator _locator;
    private Tetramino _tetramino;

    public Spawner(Creator creator, FieldEventLocator locator, Tetramino tetramino)
    {
        _creator = creator;
        _locator = locator;
        _tetramino = tetramino;

        _locator.TurnDoned += Spawn;
    }

    public event Action TetraminoSpawned;

    public void Dispose()
    {
        _locator.TurnDoned -= Spawn;
    }

    public void Spawn()
    {
        BlockMaterial material = _creator.PickRandomMaterial();
        Shape shape = _creator.PickRandomShape();

        _tetramino.CreateNew(shape, material);
            
        TetraminoSpawned?.Invoke();
        Debug.Log("Spawner Spawned");
    }
}
