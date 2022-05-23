﻿using UnityEngine;
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
        Initialize();
    }

    public void Initialize()
    {
        foreach (HighscoreEntry entry in _tableModel.SortedList)
        {
            HighscoreEntryView entryView
                = _template.GetComponent<HighscoreEntryView>();
            string place = _place++.ToString();
            string score = entry.ScoreValue.ToString();
            entryView.SetScore(place, score, entry.NickName);
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
