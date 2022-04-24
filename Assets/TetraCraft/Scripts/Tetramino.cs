using System;
using UnityEngine;

public class Tetramino : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Field _field;

    private Vector2Int[] _blocks;
    private BlockMaterial _material;

    public void Init(Shape shape, BlockMaterial material)
    {
        _material = material;
        Vector2Int spawnerPosition = new Vector2Int(3, 17);
        _blocks = new Vector2Int[4];
        for (int i = 0; i < _blocks.Length; i++)
        {
            Vector2Int position = shape.Positions[i] + spawnerPosition;
            _blocks[i] = position;
        }
    }

    public event Action Falled;
    public event Action<Vector2Int[]> TetraminoMoved;

    public Vector2Int[] Blocks => _blocks;
    public BlockMaterial Material => _material;

    public void TryMoveLeft()
    {
        if (_field.IsCanMoveLeft(_blocks) == false)
        {
            return;
        }

        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i].x--;
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

        Rotate();
        TetraminoMoved?.Invoke(_blocks);
    }

    private void Rotate()
    {
        throw new NotImplementedException();
    }

    public void TryMoveRight()
    {
        if (_field.IsCanMoveRight(_blocks) == false)
        {
            return;
        }

        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i].x++;
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
            _blocks[i].y--;
        }
        TetraminoMoved?.Invoke(_blocks);
    }

    public void ReachBottom()
    {
        Falled?.Invoke();
        _timer.EndBoost();
    }
}
