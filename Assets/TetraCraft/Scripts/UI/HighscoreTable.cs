using System.Collections.Generic;
using System.Linq;

public class HighscoreTable
{
    private const int MaxEntries = 10;
    private List<HighscoreEntry> _entries;

    public HighscoreTable()
    {
        _entries = new List<HighscoreEntry>(MaxEntries);
    }

    private IOrderedEnumerable<HighscoreEntry> SortedList 
        => _entries.OrderBy((e) => e.Score);
}
