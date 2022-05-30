using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(Constants.SceneNames.GameField);
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(Constants.SceneNames.Settings);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(Constants.SceneNames.MainMenu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
