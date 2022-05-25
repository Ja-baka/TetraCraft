using System;

[Serializable]
public class HighscoreEntry
{
    private readonly string _nickName;
    private readonly int _scoreValue;

    public HighscoreEntry(string name, int score)
    {
        _nickName = name;
        _scoreValue = score;
    }

    public static int NewScoreValue { get; set; }
    public static string NewScoreNickname { get; set; }

    public string NickName => _nickName;
    public int ScoreValue => _scoreValue;
}
