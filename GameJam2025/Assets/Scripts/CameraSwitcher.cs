using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> cameras; // List of your Cinemachine cameras
    private int currentCameraIndex = 0; // Index of the currently active camera

    void Start()
    {
        // Ensure only the first camera is enabled at the start
        ActivateCamera(currentCameraIndex);
    }

    void Update()
    {
        // Switch to the left camera when pressing Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentCameraIndex = (currentCameraIndex - 1 + cameras.Count) % cameras.Count;
            ActivateCamera(currentCameraIndex);
        }

        // Switch to the right camera when pressing E
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Count;
            ActivateCamera(currentCameraIndex);
        }
    }

    private void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].SetActive(i == index); // Activate the selected camera and deactivate the others
        }
    }
}
