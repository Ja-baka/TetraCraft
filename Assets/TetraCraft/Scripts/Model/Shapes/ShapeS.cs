public class ShapeS : Shape
{
    protected override bool[,] CreateRotate1()
    {
        return new bool[,]
        {
            { O, I, I },
            { I, I, O },
            { O, O, O },
        };
    }

    protected override bool[,] CreateRotate2()
    {
        return new bool[,]
        {
            { O, I, O },
            { O, I, I },
            { O, O, I },
        };
    }

    protected override bool[,] CreateRotate3()
    {
        return new bool[,]
        {
            { O, O, O },
            { O, I, I },
            { I, I, O },
        };
    }

    protected override bool[,] CreateRotate4()
    {
        return new bool[,]
        {
            { I, O, O },
            { I, I, O },
            { O, I, O },
        };
    }
}
