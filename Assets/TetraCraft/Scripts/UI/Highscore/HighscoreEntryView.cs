using UnityEngine;
using Zenject;
using TMPro;

public class HighscoreEntryView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _place;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _recordHolderName;

    public void SetScore(string place, string score, string recordHolderName)
    {
        _place.text = place;
        _score.text = score;
        _recordHolderName.text = recordHolderName;
    }
}
