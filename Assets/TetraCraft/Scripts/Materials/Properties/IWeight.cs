using UnityEngine;

public interface IWeight
{
    void Fall(Vector2Int current, ref BlockMaterial[,] field, bool isAfterCleaning);
}