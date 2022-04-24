using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveTetramino : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Field _field;

    private Block[] _blocks;
    private GameObject[] _cubes;

    public void Init(Shape shape, BlockMaterial material)
    {
        _blocks = new Block[4];
        _cubes = new GameObject[4];
        Vector2Int spawnerPosition = new Vector2Int(3, 17);
        for (int i = 0; i < _blocks.Length; i++)
        {
            Vector2Int position = shape.Positions[i] + spawnerPosition;
            _blocks[i] = new Block(position, material);
        }
    }

    public event Action<GameObject[]> Falled;
    public event Action<Block[]> TetraminoMoved;

    public Block[] Blocks => _blocks;

    public void TryMoveLeft()
    {
        if (_field.IsCanMoveLeft(_blocks) == false)
        {
            return;
        }

        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i].MoveLeft();
        }
        TetraminoMoved?.Invoke(_blocks);
    }

    public void TryRotate()
    {
        if (_field.IsCanRotate() == false)
        {
            Debug.Log("Can't Rotate");
            return;
        }

        Vector2Int[] positions = GetRotated
        (
            _blocks
                .ToList()
                .Select
                (
                    (b) => b.Position
                )
                .ToArray()
        );
        foreach (Block block in _blocks)
        {
            Debug.Log(block.Position);
        }
        print("-----------------------");
        foreach (Vector2Int position in positions)
        {
            Debug.Log(position);
        }

        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i].SetPosition(positions[i]);
        }
        TetraminoMoved?.Invoke(_blocks);
    }

    public Vector2Int[] GetRotated(Vector2Int[] sourceShape)
    {
        List<Vector2Int> rotated = new List<Vector2Int>(sourceShape);
        rotated.ForEach((p) => (p.x, p.y) = (p.y, p.x));
        int width = Math.Max(rotated.Max((p) => p.x), rotated.Max((p) => p.y));
        rotated.ForEach((p) => p.y = width - p.y);

        return rotated.ToArray();
    }

    public void TryMoveRight()
    {
        if (_field.IsCanMoveRight(_blocks) == false)
        {
            return;
        }

        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i].MoveRight();
        }
        TetraminoMoved?.Invoke(_blocks);
    }

    private void OnEnable()
    {
        _timer.Tick += TryFall;
    }

    private void OnDisable()
    {
        _timer.Tick -= TryFall;
    }

    private void TryFall()
    {
        if (_field.IsCanFall(_blocks) == false)
        {
            ReachBottom();
            return;
        }

        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i].Fall();
        }
        TetraminoMoved?.Invoke(_blocks);
    }

    public void ReachBottom()
    {
        Falled?.Invoke(_cubes);
        _timer.EndBoost();
    }
}
