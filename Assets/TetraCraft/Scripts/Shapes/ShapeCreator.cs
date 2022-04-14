public class ShapeCreator : Creator<Shape>
{
    protected override Shape[] FillArray()
    {
        return new Shape[]
        {
            new ShapeI(),
        };
    }
}
