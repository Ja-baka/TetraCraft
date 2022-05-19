using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

[Serializable]
public class HighscoresTable
{
    private const int MaxEntries = 10;
    private List<HighscoreEntry> _entries;

    [Inject]
    public HighscoresTable(NewHighscore newHighscore)
    {
        _entries = new List<HighscoreEntry>(MaxEntries);
    }

    public IOrderedEnumerable<HighscoreEntry> SortedList 
        => _entries.OrderBy((e) => e.Score);
}
