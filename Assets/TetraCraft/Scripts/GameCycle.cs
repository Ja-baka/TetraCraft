using UnityEngine;

public static class GameCycle
{
    private static bool _playing = true;

    public static bool Playing => _playing;

    public static void GameOver()
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
