using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/BlockMaterial/Properties/Weight/Viscous", fileName = "Viscous")]
public class Viscous : ScriptableObject, IWeight
{
    public void Fall(Vector2Int current, ref BlockMaterial[,] field, bool isAfterCleaning)
    {
        Vector2Int bellow = current + Vector2Int.down;
        if (isAfterCleaning
            || bellow.y < 0
            || field[bellow.x, bellow.y] != null)
        {
            return;
        }

        field[bellow.x, bellow.y] = field[current.x, current.y];
        field[current.x, current.y] = null;
    }
}
