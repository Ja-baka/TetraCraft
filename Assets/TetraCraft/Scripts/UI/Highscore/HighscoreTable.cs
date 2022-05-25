using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

[Serializable]
public class HighscoresTable : IDisposable
{
    private const int MaxEntries = 10;
    private List<HighscoreEntry> _entries;
    private Storage _storage;
    private INicknameGetter _nicknameGetter;
    private int _newScoreValue;

    public Action Updated;

    [Inject]
    public HighscoresTable(INicknameGetter nicknameGetter)
    {
        _nicknameGetter = nicknameGetter;

        _newScoreValue = HighscoreEntry.NewScoreValue;
        _storage = new Storage();
        _entries = _storage.Load(new List<HighscoreEntry>(MaxEntries));

        _nicknameGetter.NickGetted += OnNickGetted;
        CheckOnHighscore();
    }

    public void Dispose()
    {
        _nicknameGetter.NickGetted -= OnNickGetted;
    }

    private void CheckOnHighscore()
    {
        if (HasSpace()
            || IsHighScore(_newScoreValue))
        {
            _nicknameGetter.Show();
        }
        else
        {
            Updated?.Invoke();
        }
    }

    private void OnNickGetted()
    {
        string nickname = _nicknameGetter.Nickname;
        TryAddNewScore(new HighscoreEntry(nickname, _newScoreValue));
        Updated?.Invoke();
    }

    public void SaveTable()
    {
        _storage.Save(_entries);
    }

    public void TryAddNewScore(HighscoreEntry entry)
    {
        if (HasSpace())
        {
            _entries.Add(entry);
            return;
        }

        if (IsHighScore(entry.ScoreValue))
        {
            _entries.Remove(SortedList.Last());
            _entries.Add(entry);
        }
    }

    private bool HasSpace()
    {
        return _entries.Count < MaxEntries;
    }

    private bool IsHighScore(int scoreValue)
    {
        int minScore = _entries.Any()
            ? _entries.Min((record) => record.ScoreValue)
            : 0;

        return scoreValue > minScore;
    }

    public IOrderedEnumerable<HighscoreEntry> SortedList
        => _entries.OrderByDescending((e) => e.ScoreValue);
}
