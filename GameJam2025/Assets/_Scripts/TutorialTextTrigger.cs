using System.Collections;
using UnityEngine;

public class TriggerTutorialUI : MonoBehaviour
{
    public GameObject objectToToggle; // The object that will be toggled
    private bool isInTrigger = false; // To check if the player is inside the trigger

    void Start()
    {
        // Ensure the object starts off
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger zone
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
            objectToToggle.SetActive(true); // Activate the object
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player has left the trigger zone
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }

    void Update()
    {
        // If the player is inside the trigger and presses Q or E
        if (isInTrigger && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)))
        {
            objectToToggle.SetActive(false); // Deactivate the object
        }
    }
}
