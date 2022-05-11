using UnityEngine;

public class GameCycle : MonoBehaviour
{
    private bool _playing = true;

    public void GameOver()
    {
        if (_playing == false)
        {
            return;
        }
        _playing = false;

        Debug.Log("Game Over");
        Application.Quit();

        Time.timeScale = 0;
    }
}
