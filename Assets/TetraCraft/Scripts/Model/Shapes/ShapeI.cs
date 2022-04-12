using UnityEngine;

public class ShapeI : Shape
{
    protected override void CreateRotate1(out Vector2Int[] rotate)
    {
        rotate = new Vector2Int[4];

        rotate[0].x = 0;
        rotate[0].y = 2;

        rotate[1].x = 1;
        rotate[1].y = 2;

        rotate[2].x = 2;
        rotate[2].y = 2;

        rotate[3].x = 3;
        rotate[3].y = 2;
    }

    protected override void CreateRotate2(out Vector2Int[] rotate)
    {
        rotate = new Vector2Int[4];

        rotate[0].x = 2;
        rotate[0].y = 3;

        rotate[1].x = 2;
        rotate[1].y = 2;

        rotate[2].x = 2;
        rotate[2].y = 1;

        rotate[3].x = 2;
        rotate[3].y = 0;
    }

    protected override void CreateRotate3(out Vector2Int[] rotate)
    {
        rotate = new Vector2Int[4];

        rotate[0].x = 3;
        rotate[0].y = 1;

        rotate[1].x = 2;
        rotate[1].y = 1;

        rotate[2].x = 1;
        rotate[2].y = 1;

        rotate[3].x = 0;
        rotate[3].y = 1;
    }

    protected override void CreateRotate4(out Vector2Int[] rotate)
    {
        rotate = new Vector2Int[4];

        rotate[0].x = 1;
        rotate[0].y = 0;

        rotate[1].x = 1;
        rotate[1].y = 1;

        rotate[2].x = 1;
        rotate[2].y = 2;

        rotate[3].x = 1;
        rotate[3].y = 3;
    }
}