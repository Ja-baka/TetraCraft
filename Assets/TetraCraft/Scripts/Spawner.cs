﻿using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ActiveTetramino _activeTetramino;
    [SerializeField] private MaterialCreator _materialCreator;
    [SerializeField] private ShapeCreator _shapeCreator;

    public event Action<ActiveTetramino> TetraminoSpawned;

    private void Start()
    {
        BlockMaterial material = _materialCreator.PickRandom();
        Shape shape = _shapeCreator.PickRandom();
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
