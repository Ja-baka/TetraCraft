using System.Linq;
using UnityEngine;
using Zenject;

public class TableView : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _scoresHolder;
    private HighscoresTable _tableModel;
    private int _place = 1;

    [Inject]
    public void Construct(HighscoresTable highscoresTable)
    {
        _tableModel = highscoresTable;

        ScoreSaver saver = FindObjectOfType<ScoreSaver>();
        HighscoreEntry entry = new HighscoreEntry(saver.Nickname, saver.ScoreVale);

        _tableModel.AddNewScore(entry);
    }

    private void OnValidate()
    {
        if (_template.TryGetComponent(out HighscoreEntryView _) == false)
        {
            _template = null;
            throw new System.Exception("");
        }
    }

    private void Start()
    {
        foreach (HighscoreEntry entry in _tableModel.SortedList)
        {
            HighscoreEntryView entryView 
                = _template.GetComponent<HighscoreEntryView>();
            string place = _place++.ToString();
            string score = entry.Score.ToString();
            entryView.SetScore(place, score, entry.Name);
            Instantiate(entryView, _scoresHolder);
        }
    }
}
