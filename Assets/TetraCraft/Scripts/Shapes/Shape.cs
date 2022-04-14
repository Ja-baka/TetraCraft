using UnityEngine;

public abstract class Shape
{
    private const int BlockCount = 4;

    public Vector2Int[] Positions { get; }

    public Shape()
    {
        Positions = SetPosition();
        if (Positions.Length != BlockCount)
        {
            throw new System.Exception($"{GetType().Name} " +
                $"складаецца з {Positions.Length} блокаў, " +
                $"а не {BlockCount}");
        }
    }

    public void Rotate()
    {
        throw new System.NotImplementedException();
    }

    protected abstract Vector2Int[] SetPosition();
}
