using UnityEngine;

public class InteractZoneController : MonoBehaviour
{
    [SerializeField] private Canvas interactionCanvas; // Canvas to display when the player enters
    [SerializeField] private GameObject interactableObject; // Object to interact with
    private bool isPlayerInZone = false; // Tracks if the player is in the trigger zone

    void Start()
    {
        // Ensure the canvas is hidden initially
        if (interactionCanvas != null)
        {
            interactionCanvas.enabled = false;
        }
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
                FindObjectOfType<AudioManager>().Play("Key");

                // Optionally, hide the canvas after interacting
                if (interactionCanvas != null)
                {
                    interactionCanvas.enabled = false;
                }
            }
        }
    }
}
