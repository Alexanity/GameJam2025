using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class MainMenu : MonoBehaviour
{
    // Method to quit the application
    public void Quit()
    {
        Debug.Log("Quit Game"); // Logs in the Editor (won't appear in builds)
        Application.Quit();
    }

    // Method to load the next scene
    public void Play()
    {
        // Get the currently active scene's index and load the next one
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Make sure the next scene exists before loading it
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No next scene to load! Ensure your build settings have multiple scenes.");
        }
    }
}
