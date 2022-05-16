using UnityEngine;
using Zenject;

public class HighscoreEntryView : MonoBehaviour
{
    [Inject]
    public void Construct(HighscoreTable table)
    {

    }
}
