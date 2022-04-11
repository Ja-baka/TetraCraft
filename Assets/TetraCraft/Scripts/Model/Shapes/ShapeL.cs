internal class ShapeL : Shape
{
    protected override bool[,] CreateRotate1()
    {
        return new bool[,]
        {
            { O, O, I },
            { I, I, I },
            { O, O, O },
        };
    }

    protected override bool[,] CreateRotate2()
    {
        return new bool[,]
        {
            { O, I, O },
            { O, I, O },
            { O, I, I },
        };
    }

    protected override bool[,] CreateRotate3()
    {
        return new bool[,]
        {
            { O, O, O },
            { I, I, I },
            { I, O, O },
        };
    }

    protected override bool[,] CreateRotate4()
    {
        return new bool[,]
        {
            { I, I, O },
            { O, I, O },
            { O, I, O },
        };
    }
}
