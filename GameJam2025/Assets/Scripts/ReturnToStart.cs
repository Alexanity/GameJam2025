using UnityEngine;

public class ReturnToStart : MonoBehaviour
{
    public Transform player; // The player's Transform
    private Vector3 playerSpawnPosition; // The player's spawn position
    private CharacterController characterController; // Reference to the CharacterController

    void Start()
    {
        if (player != null)
        {
            playerSpawnPosition = player.position;

            // Get the CharacterController component from the player
            characterController = player.GetComponent<CharacterController>();
            if (characterController == null)
            {
                Debug.LogError("No CharacterController found on the player!");
            }
        }
        else
        {
            Debug.LogError("Player Transform is not assigned.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("FELL");
            FindObjectOfType<AudioManager>().Play("Fail"); // ADD AUDIO
            // Disable the CharacterController temporarily to teleport
            if (characterController != null)
            {
                characterController.enabled = false; // Turn off the CharacterController
            }

            // Teleport the player back to the spawn position
            player.position = playerSpawnPosition;

            // Re-enable the CharacterController after teleporting
            if (characterController != null)
            {
                characterController.enabled = true;
            }

            Debug.Log("Player returned to spawn position: " + playerSpawnPosition);
        }
    }
}
