using UnityEngine;

public static class TetraminoValidator
{
    public const int ExpectedBlocksCount = 4;

    public static bool Validate(Vector2Int[][] rotates)
    {
        foreach (Vector2Int[] rotate in rotates)
        {
            if (rotate.Length != ExpectedBlocksCount)
            {
                return false;
            }
        }
        return true;
    }
}
