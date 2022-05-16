using System;

public class HighscoreEntry : IComparable<HighscoreEntry>
{
    private readonly string _name;
    private readonly int _score;

    public HighscoreEntry()
    {
        _name = string.Empty;
        _score = 0;
    }

    public HighscoreEntry(string name, int score)
    {
        _name = name;
        _score = score;
    }

    public string Name => _name;
    public int Score => _score;

    public int CompareTo(HighscoreEntry other)
    {
        throw new NotImplementedException();
    }
}
