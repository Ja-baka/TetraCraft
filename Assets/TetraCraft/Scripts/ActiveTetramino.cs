using System;
using UnityEngine;

public class ActiveTetramino : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    private Shape _shape;
    private BlockMaterial _material;
    private Block[] _blocks;

    public void Init(Shape shape, BlockMaterial material)
    {
        _shape = shape;
        _material = material;
        _blocks = new Block[4];
        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i] = new Block(shape.Positions[i], _material);
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
        Debug.Log("Fall");
    }

    public void ReachBottom()
    {
        Falled?.Invoke();
        enabled = false;
    }
}
