using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene Names")]
    public string gameSceneName = "test scene"; // Replace with your actual gameplay scene name

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenSettings()
    {
        // For now, just log — you can later open a settings panel
        Debug.Log("Settings menu coming soon!");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
