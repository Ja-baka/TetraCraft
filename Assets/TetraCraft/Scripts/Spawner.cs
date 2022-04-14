using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ActiveTetramino _activeTetramino;
    private Vector2Int _spawnPosition;

    public event Action<ActiveTetramino> TetraminoSpawned;

    private void Awake()
    {
        BlockMaterial material = new MaterialCreator().PickRandom();
        Shape shape = new ShapeCreator().PickRandom();

        throw new NotImplementedException();
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
        TetraminoSpawned?.Invoke(_activeTetramino);
        throw new NotImplementedException();
    }
}
