public class NewHighscore
{
    private HighscoreEntry _entry;

    public void Set(string name, int score)
    {
        _entry = new HighscoreEntry(name, score);
    }

    public HighscoreEntry Entry => _entry
        ?? throw new System.Exception("First Call Set()"); 
}
