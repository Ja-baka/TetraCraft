using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

[Serializable]
public class HighscoresTable
{
    private const int MaxEntries = 10;
    private List<HighscoreEntry> _entries;
    private HighscoreEntry _highscoreEntry;

    [Inject]
    public HighscoresTable()
    {
        Storage storage = new Storage();
        _entries = storage.Load(new List<HighscoreEntry>(MaxEntries))
            as List<HighscoreEntry>;

        //AddNewHighscore();
    }

    public void AddNewScore(HighscoreEntry entry)
    {
        int minScore = _entries.Any()
            ? _entries.Min((record) => record.Score)
            : 0;

        if (_entries.Count >= MaxEntries
            && entry.Score <= minScore)
        {
            return;
        }

        if (_entries.Count >= MaxEntries)
        {
            _entries.Remove(SortedList.Last());
        }
        _entries.Add(entry);
    }

    private void AddNewHighscore()
    {
        int minScore = _entries.Any()
            ? _entries.Min((record) => record.Score)
            : 0;

        if (_entries.Count >= MaxEntries
            && _highscoreEntry.Score <= minScore)
        {
            return;
        }

        if (_entries.Count >= MaxEntries)
        {
            _entries.Remove(SortedList.Last());
        }
        _entries.Add(_highscoreEntry);
    }

    public IOrderedEnumerable<HighscoreEntry> SortedList
        => _entries.OrderByDescending((e) => e.Score);
    public List<HighscoreEntry> Entries => _entries;
}
