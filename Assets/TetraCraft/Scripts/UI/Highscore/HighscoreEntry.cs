using System;

[Serializable]
public class HighscoreEntry
{
    private readonly string _name;
    private readonly int _score;

    public HighscoreEntry(string name, int score)
    {
        _name = name;
        _score = score;
    }

    public string Name => _name;
    public int Score => _score;
}
