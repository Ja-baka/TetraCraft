using System;

public class FieldEventLocator
{
    public event Action<BlockMaterial[,]> Updated;
    public event Action TurnDoned;
    public event Action LineCleared;
    public event Action GameOvered;

    public bool _isPlaying = true;

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

    public void TryGameOver()
    {
        if (_isPlaying == false)
        {
            //return;
        }
        _isPlaying = false;

        GameOvered?.Invoke();
    }
}
