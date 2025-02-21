using Cinemachine;
using UnityEngine;

public class CameraMenuController : MonoBehaviour
{
    public CinemachineDollyCart dollyCart; // Reference to the Dolly Cart
    public float[] menuPositions; // Positions for each menu on the dolly track
    public Transform[] lookAtTargets; // Look-at targets for each menu
    public float moveSpeed = 1f; // Speed of movement along the path
    public float rotationSpeed = 5f; // Speed of rotation towards the look-at target

    private int targetMenuIndex = 0;
    private bool isMoving = false;

    void Update()
    {
        if (dollyCart != null && isMoving)
        {
            // Move the cart towards the target position
            float targetPosition = menuPositions[targetMenuIndex];
            dollyCart.m_Position = Mathf.MoveTowards(dollyCart.m_Position, targetPosition, moveSpeed * Time.deltaTime);

            // Smoothly rotate the camera to look at the target
            if (lookAtTargets[targetMenuIndex] != null)
            {
                Vector3 direction = lookAtTargets[targetMenuIndex].position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            // Stop moving when the camera reaches the target position
            if (Mathf.Abs(dollyCart.m_Position - targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }

    // Call this method to move the camera to a specific menu
    public void MoveToMenu(int menuIndex)
    {
        if (menuIndex >= 0 && menuIndex < menuPositions.Length)
        {
            targetMenuIndex = menuIndex;
            isMoving = true;
        }
        else
        {
            Debug.LogWarning("Invalid menu index!");
        }
    }
}