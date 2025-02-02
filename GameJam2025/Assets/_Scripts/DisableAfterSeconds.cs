using UnityEngine;

public class DisableAfterSeconds : MonoBehaviour
{
    // Reference to the GameObject to disable
    public GameObject targetObject;

    // Time in seconds before the object is disabled
    public float disableAfterSeconds = 5f;

    private void OnEnable()
    {
        // If no target is set, default to this GameObject
        if (targetObject == null)
        {
            targetObject = gameObject;
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
    }

    private void OnDisable()
    {
        // Cancel the invoke in case the object is re-enabled before the timer completes
        CancelInvoke(nameof(DisableObject));
    }
}
