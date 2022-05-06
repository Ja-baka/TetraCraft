using System;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/BlockMaterial/Properties/Weight/Hanging", fileName = "Hanging")]
public class Hanging : ScriptableObject, IWeight
{
    public void Fall(Vector2Int current, ref BlockMaterial[,] field)
    {
    }
}

