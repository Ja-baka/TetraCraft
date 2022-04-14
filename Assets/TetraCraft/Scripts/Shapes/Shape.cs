using UnityEngine;

public abstract class Shape
{
    public abstract Vector2Int[] Positions { get; }

    public void Rotate()
    {
        throw new System.NotImplementedException();
    }
}
