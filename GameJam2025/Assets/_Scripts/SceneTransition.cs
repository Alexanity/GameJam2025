using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject startSceneTransition; // Transition effect at the start of the scene
    [SerializeField] private GameObject endSceneTransition; // Transition effect at the end of the scene
    [SerializeField] private string SceneName; // Name of the scene to load
    [SerializeField] private GameObject trackedObject; // Object to monitor for disappearance
    [SerializeField] private GameObject objectToActivateOnStart; // Object to activate when the scene starts

    private void Start()
    {
        // Play fade-in transition at the start of the scene
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (startSceneTransition != null)
            {
                startSceneTransition.SetActive(true);
                Invoke("DisableStartingSceneTransition", 1.5f);
            }
        }

        // Activate the specified object when the scene starts
        if (objectToActivateOnStart != null)
        {
            objectToActivateOnStart.SetActive(true);
        }
    }

    private void DisableStartingSceneTransition()
    {
        if (startSceneTransition != null)
        {
            startSceneTransition.SetActive(false);
        }
    }

    private void Update()
    {
        // Check if the tracked object has been destroyed or deactivated
        if (trackedObject == null || !trackedObject.activeSelf)
        {
            TriggerSceneTransition();
        }
    }

    public void PlayTransition()
    {
        TriggerSceneTransition();
    }

    private void TriggerSceneTransition()
    {
        // Play the end scene transition effect
        if (endSceneTransition != null)
        {
            endSceneTransition.SetActive(true);
        }

        // Load the next scene after a short delay
        Invoke("LoadNextScene", 1.5f);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
