using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> cameras; // List of cameras in the desired order
    private int currentCameraIndex = 0; // Start with the first camera

    void Start()
    {
        if (cameras == null || cameras.Count == 0)
        {
            Debug.LogError("No cameras assigned in the CameraSwitcher script! Please assign them in the Inspector.");
            return;
        }

        // Ensure only the first camera is enabled at the start
        ActivateCamera(currentCameraIndex);
    }

    void Update()
    {
        // Move to the next camera (right) when pressing E
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Count; // Increment and loop back to 0
            ActivateCamera(currentCameraIndex);
            Debug.Log($"Switched to Camera: {currentCameraIndex + 1}");
            FindObjectOfType<AudioManager>().Play("Camera");
        }

        // Move to the previous camera (left) when pressing Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentCameraIndex = (currentCameraIndex - 1 + cameras.Count) % cameras.Count; // Decrement and loop back to the last
            ActivateCamera(currentCameraIndex);
            Debug.Log($"Switched to Camera: {currentCameraIndex + 1}");
            FindObjectOfType<AudioManager>().Play("Camera");
        }
    }

    private void ActivateCamera(int index)
    {
        // Activate the selected camera and deactivate all others
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].SetActive(i == index);
        }
    }
}
