public class ShapeO : Shape
{
    protected override bool[,] CreateRotate1()
    {
        return new bool[,]
        {
            { O, I, I, O },
            { O, I, I, O },
            { O, O, O, O },
            { O, O, O, O },
        };
    }

    protected override bool[,] CreateRotate2()
    {
        return new bool[,]
        {
            { O, I, I, O },
            { O, I, I, O },
            { O, O, O, O },
            { O, O, O, O },
        };
    }

    protected override bool[,] CreateRotate3()
    {
        return new bool[,]
        {
            { O, I, I, O },
            { O, I, I, O },
            { O, O, O, O },
            { O, O, O, O },
        };
    }

    protected override bool[,] CreateRotate4()
    {
        return new bool[,]
         {
            { O, I, I, O },
            { O, I, I, O },
            { O, O, O, O },
            { O, O, O, O },
         };
    }
}
