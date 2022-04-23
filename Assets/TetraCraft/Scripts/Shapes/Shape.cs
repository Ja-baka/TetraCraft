using System;
using System.Collections.Generic;
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
            throw new Exception($"{GetType().Name} " +
                $"складаецца з {Positions.Length} блокаў, " +
                $"а не {BlockCount}");
        }
    }

    public void Rotate()
    {
        throw new NotImplementedException();
    }
}
