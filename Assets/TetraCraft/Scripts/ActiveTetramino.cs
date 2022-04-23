using System;
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
        for (int i = 0; i < _blocks.Length; i++)
        {
            Vector2Int position = shape.Positions[i];
            _blocks[i] = new Block(position, material);
        }
    }

    public event Action<GameObject[]> Falled;
    public event Action<Vector2Int> TetraminoMoved;

    public Block[] Blocks => _blocks;

    public void TryMoveLeft()
    {
        if (_field.IsCanMoveLeft(_blocks) == false)
        {
            return;
        }

        TetraminoMoved?.Invoke(Vector2Int.left);
        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i].MoveLeft();
        }
    }

    public void TryMoveRight()
    {
        if (_field.IsCanMoveRight(_blocks) == false)
        {
            return;
        }

        TetraminoMoved?.Invoke(Vector2Int.right);
        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i].MoveRight();
        }
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

        TetraminoMoved?.Invoke(Vector2Int.down);
        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i].Fall();
        }
    }

    public void ReachBottom()
    {
        Falled?.Invoke(_cubes);
        _timer.EndBoost();
    }
}
