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
    public HighscoresTable(NewHighscore newHighscore)
    {
        _highscoreEntry = newHighscore.Entry;

        Storage storage = new Storage();
        _entries = storage.Load(new List<HighscoreEntry>(MaxEntries))
            as List<HighscoreEntry>;

        AddNewHighscore();
    }

    private void AddNewHighscore()
    {
        int minScore = _entries.Min((record) => record.Score);

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
}
