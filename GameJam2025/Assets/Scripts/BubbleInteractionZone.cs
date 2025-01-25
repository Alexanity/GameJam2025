using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load scenes

public class BubbleInteractionZone : MonoBehaviour
{
    [SerializeField] private Canvas interactionCanvas; // Canvas to display when the player enters
    [SerializeField] private GameObject interactableObject; // Object to interact with
    [SerializeField] private GameObject bubbleParticles; // Bubble particle effect
    [SerializeField] private string nextSceneName; // Name of the next scene to load
    private bool isPlayerInZone = false; // Tracks if the player is in the trigger zone

    void Start()
    {
        // Ensure the canvas is hidden initially
        if (interactionCanvas != null)
        {
            interactionCanvas.enabled = false;
        }
        bubbleParticles.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;

            // Show the canvas
            if (interactionCanvas != null)
            {
                interactionCanvas.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player exited the trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;

            // Hide the canvas
            if (interactionCanvas != null)
            {
                interactionCanvas.enabled = false;
            }
        }
    }

    void Update()
    {
        // Check for interaction while the player is in the zone
        if (isPlayerInZone && Input.GetKeyDown(KeyCode.F)) // 'F' for interaction
        {
            // Make the object disappear
            if (interactableObject != null)
            {
                interactableObject.SetActive(false);
                FindObjectOfType<AudioManager>().Play("Bubbles"); // Play audio from AudioManager
                bubbleParticles.SetActive(true);

                // Optionally, hide the canvas after interacting
                if (interactionCanvas != null)
                {
                    interactionCanvas.enabled = false;
                }

                // Start the coroutine to load the next scene after 2 seconds
                StartCoroutine(LoadNextSceneAfterDelay(2f));
            }
        }
    }

    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Load the next scene
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name is not specified.");
        }
    }
}
