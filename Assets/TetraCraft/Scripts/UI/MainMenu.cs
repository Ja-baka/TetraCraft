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
        throw new System.NotImplementedException();
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
