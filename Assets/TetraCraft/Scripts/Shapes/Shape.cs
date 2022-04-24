using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Shape", fileName = "Shape")]
public class Shape : ScriptableObject
{
    [SerializeField] private Vector2Int[] _positions;

    private const int RequireBlockCount = 4;

    public Vector2Int[] Positions => _positions;

    private void OnValidate()
    {
        if (Positions.Length != RequireBlockCount)
        {
            throw new Exception($"Фігура " +
                $"складаецца з {Positions.Length} блёкаў, " +
                $"замест {RequireBlockCount}");
        }
    }
}
