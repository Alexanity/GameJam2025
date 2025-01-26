using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCanvasShow : MonoBehaviour
{
    // Reference to the GameObject to disable
    public GameObject targetObject;

    // Reference to the Canvas to show after the object is disabled
    public Canvas canvasToShow;

    // Time in seconds before the object is disabled
    public float disableAfterSeconds = 5f;

    private void OnEnable()
    {
        // If no target is set, default to this GameObject
        if (targetObject == null)
        {
            targetObject = gameObject;
        }

        // If no Canvas is assigned, log a warning
        if (canvasToShow == null)
        {
            Debug.LogWarning("Canvas to show is not assigned in the Inspector!");
        }

        // Start the countdown to disable the object
        Invoke(nameof(DisableObject), disableAfterSeconds);
    }

    private void DisableObject()
    {
        // Disable the target object
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }

        // Show the Canvas
        if (canvasToShow != null)
        {
            canvasToShow.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        // Cancel the invoke in case the object is re-enabled before the timer completes
        CancelInvoke(nameof(DisableObject));
    }
}
