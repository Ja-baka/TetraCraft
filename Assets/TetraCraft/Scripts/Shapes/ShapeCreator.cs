using UnityEngine;

public class ShapeCreator : Creator<Shape>
{
    [SerializeField] private Shape[] _shapes;

    protected override Shape[] FillArray()
    {
        return _shapes;
    }
}
