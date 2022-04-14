using UnityEngine;

public class ShapeI : Shape
{
    protected override Vector2Int[] SetPosition()
    {
        return new Vector2Int[4]
        {
            new Vector2Int(3, 19),
            new Vector2Int(4, 19),
            new Vector2Int(5, 19),
            new Vector2Int(6, 19),
        };
    }
}
