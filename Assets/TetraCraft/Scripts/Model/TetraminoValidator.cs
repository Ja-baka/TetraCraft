public static class TetraminoValidator
{
    public const int ExpectedBlocksCount = 4;

    public static bool Validate(bool[][,] rotates)
    {
        foreach (bool[,] rotate in rotates)
        {
            int blocksCount = 0;
            foreach (bool isBlockExist in rotate)
            {
                blocksCount += isBlockExist ? 1 : 0;
            }
            if (blocksCount != ExpectedBlocksCount)
            {
                return false;
            }
        }
        return true;
    }
}
