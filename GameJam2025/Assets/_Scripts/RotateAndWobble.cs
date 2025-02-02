using UnityEngine;

public class RotateAndWobble : MonoBehaviour
{
    // Rotation speed around the Y-axis
    public float rotationSpeed = 50f;

    // Wobble amplitude (how far it moves up and down)
    public float wobbleAmplitude = 0.5f;

    // Wobble frequency (how fast it moves up and down)
    public float wobbleFrequency = 1f;

    // Initial position of the object
    private Vector3 startPos;

    private void Start()
    {
        // Store the initial position of the object
        startPos = transform.position;
    }

    private void Update()
    {
        // Rotate the object around its Y-axis
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);

        // Calculate the new Y position using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * wobbleFrequency) * wobbleAmplitude;

        // Apply the new position, keeping X and Z constant
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
