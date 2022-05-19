using UnityEngine;
using Zenject;
using TMPro;

public class HighscoreEntryView : MonoBehaviour
{
    [SerializeField] GameObject _recordTemplate;

    private TextMeshProUGUI _TextPlace;
    private TextMeshProUGUI _TextScore;
    private TextMeshProUGUI _TextName;
    private Storage _storage;
    private HighscoresTable _table;

    [Inject]
    public void Construct(HighscoresTable table)
    {
        _storage = new Storage();
        _table = (HighscoresTable)_storage.Load(table);
    }

    private void OnValidate()
    {
        TextMeshProUGUI[] texts = _recordTemplate
            .GetComponentsInChildren<TextMeshProUGUI>();

        if (texts.Length != 3)
        {
            _recordTemplate = null;
            throw new System.Exception();
        }

        _TextPlace = texts[0];
        _TextScore = texts[1];
        _TextName = texts[2];
    }

    private void Start()
    {
        GameObject newRecord = Instantiate(_recordTemplate, transform);

    }
}
