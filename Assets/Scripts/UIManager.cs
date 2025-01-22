using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        //make sure game over screen is hidden
        gameOverScreen.SetActive(false);
    }

    // Called when the game is over
    public void GameOver()
    {
        // Activate the Game Over screen UI element
        gameOverScreen.SetActive(true);
    }

    // Reloads the current scene to restart the game
    public void Restart()
    {
        // Get the currently active scene and reload it
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void MainMenu()
    {
        // Quit the application
        Application.Quit();

        // Stops play mode in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
    }

//same as mainmenu
    public void Quit()  
    {
        Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false;
    }
}
