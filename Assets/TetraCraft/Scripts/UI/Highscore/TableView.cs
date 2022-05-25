using UnityEngine;
using Zenject;

public class TableView : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _scoresHolder;
    private HighscoresTable _tableModel;

    [Inject]
    public void Construct(HighscoresTable highscoresTable)
    {
        _tableModel = highscoresTable;

        _tableModel.Updated += OnUpdated;
    }

    public void OnUpdated()
    {
        _tableModel.SaveTable();
        int i = 1;

        foreach (HighscoreEntry entry in _tableModel.SortedList)
        {
            HighscoreEntryView entryView
                = _template.GetComponent<HighscoreEntryView>();
            string place = i++.ToString();
            string score = entry.ScoreValue.ToString();
            string nickname = entry.NickName;

            entryView.SetScore(place, score, nickname);
            Instantiate(entryView, _scoresHolder);
        }
    }

    private void OnValidate()
    {
        if (_template.TryGetComponent(out HighscoreEntryView _) == false)
        {
            _template = null;
            throw new System.Exception("Template need component HighscoreEntryView");
        }
    }
}
