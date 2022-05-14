using System;

public class FieldEventLocator
{
    public event Action<BlockMaterial[,]> Updated;
    public event Action TurnDoned;
    public event Action LineCleared;
    public event Action GameOvered;

    public void Update(BlockMaterial[,] cells)
    {
        Updated?.Invoke(cells);
    }

    public void TurnDone()
    {
        TurnDoned?.Invoke();
    }

    public void LineClear()
    {
        LineCleared?.Invoke();
    }

    public void GameOver()
    {
        GameOvered?.Invoke();
    }
}
