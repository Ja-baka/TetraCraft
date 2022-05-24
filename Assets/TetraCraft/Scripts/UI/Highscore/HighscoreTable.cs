using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

[Serializable]
public class HighscoresTable
{
    private const int MaxEntries = 10;
    private List<HighscoreEntry> _entries;
    private Storage _storage;

    [Inject]
    public HighscoresTable()
    {
        _storage = new Storage();
        _entries = _storage.Load(new List<HighscoreEntry>(MaxEntries))
            as List<HighscoreEntry>;
    }

    public void SaveTable()
    {
        _storage.Save(_entries);
    }

    public void TryAddNewScore(HighscoreEntry entry)
    {
        int minScore = _entries.Any()
            ? _entries.Min((record) => record.ScoreValue)
            : 0;

        if (_entries.Count >= MaxEntries
            && entry.ScoreValue <= minScore)
        {
            return;
        }

        if (_entries.Count >= MaxEntries)
        {
            _entries.Remove(SortedList.Last());
        }
        _entries.Add(entry);
    }

    public IOrderedEnumerable<HighscoreEntry> SortedList
        => _entries.OrderByDescending((e) => e.ScoreValue);
}
