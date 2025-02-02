using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectSwitcherWithCamera : MonoBehaviour
{
    [Header("Objects to Hide")]
    public List<GameObject> objectsToHide; // List of objects to hide

    [Header("Object to Show")]
    public GameObject objectToShow; // Object to show when the trigger is activated

    [Header("Tag Settings")]
    public string playerTag = "Player"; // Tag to identify the player

    [Header("Camera Settings")]
    public Camera mainCamera; // Reference to the main camera

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the specified tag
        if (other.CompareTag(playerTag))
        {
            
            // Hide the specified objects
            HideObjects();

            // Show the specified object
            ShowObject();


        }
    }

    private void HideObjects()
    {
        foreach (var obj in objectsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(false); // Deactivate the object
            }
        }
    }

    private void ShowObject()
    {
        if (objectToShow != null)
        {
            objectToShow.SetActive(true); // Activate the object
        }
    }

    private void SetCameraToPerspective()
    {
        if (mainCamera != null)
        {
            // Change the camera's projection mode to Perspective
            if (mainCamera.orthographic)
            {
                mainCamera.orthographic = false;
                Debug.Log("Camera projection successfully changed to Perspective.");
            }
            else
            {
                Debug.LogWarning("Camera is already in Perspective mode.");
            }
        }
        else
        {
            Debug.LogError("Main Camera is not assigned. Please assign the Main Camera in the Inspector.");
        }
    }
}
