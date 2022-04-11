using UnityEngine;

public class ShapeFactory
{
    public static Shape GenerateRandomShape()
    {
        int shapeId = Random.Range(1, 7);

        if (shapeId == 0)
        {
            return new ShapeI();
        }
        else if (shapeId == 1)
        {
            return new ShapeJ();
        }
        else if (shapeId == 2)
        {
            return new ShapeL();
        }
        else if (shapeId == 3)
        {
            return new ShapeO();
        }
        else if (shapeId == 4)
        {
            return new ShapeS();
        }
        else if (shapeId == 5)
        {
            return new ShapeT();
        }
        else if (shapeId == 6)
        {
            return new ShapeZ();
        }
        else
        {
            throw new System.Exception();
        }
    }
}
