﻿using System;
using UnityEngine;

public class ActiveTetramino : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    private Shape _shape;
    private BlockMaterial _material;
    private Block[] _blocks;
    private GameObject[] _cubes;

    public void Init(Shape shape, BlockMaterial material)
    {
        _shape = shape;
        _material = material;
        _blocks = new Block[4];
        _cubes = new GameObject[4];
        for (int i = 0; i < _blocks.Length; i++)
        {
            _shape.Positions[i].y--;
            Vector2Int position = _shape.Positions[i];
            _blocks[i] = new Block(position, _material);

            // View
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetParent(transform, false);
            cube.transform.position = new Vector3(position.x, position.y);
            cube.GetComponent<Renderer>().material = _material.Material;
            _cubes[i] = cube;
            // View
        }

        enabled = true;
    }

    public event Action Falled;
    public event Action<Vector2Int> Moved;

    public Shape Shape => _shape;
    public BlockMaterial Material => _material;
    public Block[] Blocks => _blocks;

    private void OnEnable()
    {
        _timer.Tick += Fall;
    }

    private void OnDisable()
    {
        _timer.Tick -= Fall;
    }

    public void Fall()
    {
        for (int i = 0; i < _blocks.Length; i++)
        {
            Vector2Int position = _shape.Positions[i];
            _blocks[i].Fall();

            // View
            _cubes[i].transform.position += Vector3.down;
            // View
        }
    }

    public void ReachBottom()
    {
        Falled?.Invoke();
        enabled = false;
    }
}
