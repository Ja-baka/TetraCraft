using System;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/BlockMaterial/Properties/Weight/Falling", fileName = "Falling")]
public class Falling : ScriptableObject, IWeight
{
    public void Fall(Vector2Int current, ref BlockMaterial[,] field)
    {
        Vector2Int bellow = current + Vector2Int.down;
        if (bellow.y < 0
            || field[bellow.x, bellow.y] != null)
        {
            return;
        }

        field[bellow.x, bellow.y] = field[current.x, current.y];
        field[current.x, current.y] = null;
    }
}

