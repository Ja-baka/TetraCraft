using UnityEngine;

public class ShapeI : Shape
{
    private Vector2Int[] _positions;

    public ShapeI()
    {
        _positions = new Vector2Int[4];
        throw new System.NotImplementedException();
    }

    public override Vector2Int[] Positions => _positions;
}
