public class ShapeZ : Shape
{
    protected override bool[,] CreateRotate1()
    {
        return new bool[,]
        {
            { I, I, O },
            { O, I, I },
            { O, O, O },
        };
    }

    protected override bool[,] CreateRotate2()
    {
        return new bool[,]
        {
            { O, O, I },
            { O, I, I },
            { O, I, O },
        };
    }

    protected override bool[,] CreateRotate3()
    {
        return new bool[,]
        {
            { O, O, O },
            { I, I, O },
            { O, I, I },
        };
    }

    protected override bool[,] CreateRotate4()
    {
        return new bool[,]
        {
            { O, I, O },
            { I, I, O },
            { I, O, O },
        };
    }
}
