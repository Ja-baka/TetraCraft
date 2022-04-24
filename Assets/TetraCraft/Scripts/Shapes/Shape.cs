using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Shape", fileName = "Shape")]
public class Shape : ScriptableObject
{
    [SerializeField] private Vector2Int[] _positions;

    private const int BlockCount = 4;

    public Vector2Int[] Positions => _positions;

    private void OnValidate()
    {
        if (Positions.Length != BlockCount)
        {
            throw new Exception($"Фігура " +
                $"складаецца з {Positions.Length} блокаў, " +
                $"а не {BlockCount}");
        }
    }

    public void Rotate()
    {
        Vector2Int[] rotated = (Vector2Int[])_positions.Clone();

        int delta = Math.Max
        (
            rotated.Max((p) => p.x) - rotated.Min((p) => p.x),
            rotated.Max((p) => p.y) - rotated.Min((p) => p.y)
        );
        int offset = delta - 1;
        int width = Math.Max(rotated.Max((p) => p.x), rotated.Max((p) => p.y));
        for (int i = 0; i < rotated.Length; i++)
        {
            (rotated[i].x, rotated[i].y) = (rotated[i].y, rotated[i].x);
            rotated[i].y = width - rotated[i].y;
        }
        _positions = rotated.ToArray();
    }
}
