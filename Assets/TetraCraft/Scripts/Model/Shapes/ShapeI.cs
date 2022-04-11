public class ShapeI : Shape
{
    protected override bool[,] CreateRotate1()
    {
        return new bool[,]
        {
            { O, O, O, O },
            { I, I, I, I },
            { O, O, O, O },
            { O, O, O, O },
        };
    }

    protected override bool[,] CreateRotate2()
    {
        return new bool[,]
        {
            { O, O, I, O },
            { O, O, I, O },
            { O, O, I, O },
            { O, O, I, O },
        };
    }

    protected override bool[,] CreateRotate3()
    {
        return new bool[,]
        {
            { O, O, O, O },
            { O, O, O, O },
            { I, I, I, I },
            { O, O, O, O },
        };
    }

    protected override bool[,] CreateRotate4()
    {
        return new bool[,]
         {
            { O, I, O, O },
            { O, I, O, O },
            { O, I, O, O },
            { O, I, O, O },
         };
    }
}