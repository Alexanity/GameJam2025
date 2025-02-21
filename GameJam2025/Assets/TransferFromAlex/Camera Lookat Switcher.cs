using UnityEngine;
using Cinemachine;

public class CameraLookAtSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Assign your Cinemachine Virtual Camera
    public Transform mainMenuLookAtTarget; // Assign the Main Menu Canvas LookAt target

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "CineCam" tag
        if (other.CompareTag("CineCam") && virtualCamera != null)
        {
            virtualCamera.LookAt = mainMenuLookAtTarget;
            virtualCamera.Follow = mainMenuLookAtTarget;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // When the Cinemachine camera exits, reset LookAt and disable the trigger
        if (other.CompareTag("CineCam") && virtualCamera != null)
        {
            gameObject.SetActive(false); // Disable the trigger volume
        }
    }
}
