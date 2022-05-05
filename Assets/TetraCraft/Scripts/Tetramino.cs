using System;
using System.Linq;
using UnityEngine;

public class Tetramino : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Field _field;

    private Vector2Int[] _positions;
    private BlockMaterial _material;
    private Rotator _rotator;

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

        _rotator = new Rotator(_positions);
    }

    public event Action Falled;
    public event Action TetraminoMoved;

    public Vector2Int[] Positions => _positions;
    public BlockMaterial Material => _material;

    public void TryRotate()
    {
        Vector2Int[] rotated = _rotator.GetRotated();
        TryMove(IsCanRotate(), rotated);
    }

    public void TryMoveLeft()
    {
        TryMove<Func<Vector2Int, Vector2Int>>
        (
            IsCanMoveLeft(), 
            (p) => p + Vector2Int.left
        );
    }

    public void TryMoveRight()
    {
        TryMove<Func<Vector2Int, Vector2Int>>
        (
            ISCanMoveRight(), 
            (p) => p + Vector2Int.right
        );
    }

    private void OnEnable()
    {
        _timer.Tick += TryFall;
    }

    private void OnDisable()
    {
        _timer.Tick -= TryFall;
    }

    private bool IsCanFall()
    {
        return IsCanMove((p) => p + Vector2Int.down);
    }

    private bool IsCanRotate()
    {
        Vector2Int[] rotated = _rotator.GetRotated();
        bool isCan = IsCanMove(rotated);
        if (isCan)
        {
            _rotator.NextTurn();
        }

        return isCan; 
    }

    private bool IsCanMoveLeft()
    {
        return IsCanMove((p) => p + Vector2Int.left);
    }

    private bool ISCanMoveRight()
    {
        return IsCanMove((p) => p + Vector2Int.right);
    }

    private bool IsCanMove(Vector2Int[] moved)
    {
        return moved.All((p) => IsInField(p) && IsFree(p));
    }

    private bool IsCanMove(Func<Vector2Int, Vector2Int> move)
    {
        return _positions.All((p) => IsInField(move(p)) && IsFree(move(p)));
    }

    private bool IsFree(Vector2Int offsetted)
    {
        return _positions.Contains(offsetted)
            || _field.FieldView[offsetted.x, offsetted.y] == null;
    }

    private bool IsInField(Vector2Int offsetted)
    {
        return offsetted.x >= 0
            && offsetted.x < _field.FieldView.GetLength(0)
            && offsetted.y >= 0
            && offsetted.y < _field.FieldView.GetLength(1);
    }

    private void TryFall()
    {
        if (IsCanFall() == false)
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

    private void TryMove<T>(bool isCanMove, T move)
    {
        if (isCanMove == false)
        {
            return;
        }

        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i] = MoveBlock(i, move);
        }
        TetraminoMoved?.Invoke();
    }

    private Vector2Int MoveBlock<T>(int i, T move)
    {
        return move is Func<Vector2Int, Vector2Int> moveFunc
            ? moveFunc(_positions[i])
            : move is Vector2Int[] movedBlocks 
                ? movedBlocks[i] 
                : throw new Exception();
    }

    private void ReachBottom()
    {
        Falled?.Invoke();
        _timer.EndBoost();
    }
}
