using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    // This method is called when another collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Load the next scene based on the build index
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            // Check if the next scene index is valid
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("No more scenes to load.");
            }
        }
    }
}
