using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSaver : MonoBehaviour
{
    private Score _score;
    private int _scoreValue;
    private string _nickname;

    public void Construct(Score score)
    {
        _score = score;
        _score.ScoreUpdated += OnScoreUpdated;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnScoreUpdated()
    {
        _scoreValue = _score.ScoreValue;
        _nickname = "PlaceHolder";
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.MoveGameObjectToScene(gameObject, currentScene);
    }

    public string Nickname => _nickname;
    public int ScoreVale => _scoreValue;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
