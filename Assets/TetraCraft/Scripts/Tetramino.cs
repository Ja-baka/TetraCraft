using System;
using UnityEngine;

public class Tetramino : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Field _field;

    private Vector2Int[] _positions;
    private BlockMaterial _material;

    public void Init(Shape shape, BlockMaterial material)
    {
        _material = material;
        Vector2Int spawnerPosition = new Vector2Int(3, 17);
        _positions = new Vector2Int[4];
        for (int i = 0; i < _positions.Length; i++)
        {
            Vector2Int position = shape.Positions[i] + spawnerPosition;
            _positions[i] = position;
        }
    }

    public event Action Falled;
    public event Action TetraminoMoved;

    public Vector2Int[] Positions => _positions;
    public BlockMaterial Material => _material;

    public void TryMoveLeft()
    {
        if (_field.IsCanMoveLeft(_positions) == false)
        {
            return;
        }

        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i].x--;
        }
        TetraminoMoved?.Invoke();
    }

    public void TryRotate()
    {
        if (_field.IsCanRotate() == false)
        {
            Debug.Log("Can't Rotate");
            return;
        }

        Rotate();
        TetraminoMoved?.Invoke();
    }

    private void Rotate()
    {
        throw new NotImplementedException();
    }

    public void TryMoveRight()
    {
        if (_field.IsCanMoveRight(_positions) == false)
        {
            return;
        }

        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i].x++;
        }
        TetraminoMoved?.Invoke();
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
        if (_field.IsCanFall(_positions) == false)
        {
            ReachBottom();
            return;
        }

        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i].y--;
        }
        TetraminoMoved?.Invoke();
    }

    public void ReachBottom()
    {
        Falled?.Invoke();
        _timer.EndBoost();
    }
}
