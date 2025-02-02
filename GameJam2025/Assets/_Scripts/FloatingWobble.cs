using UnityEngine;

public class FloatingWobble : MonoBehaviour
{
    // Amplitude of the wobble (how far up and down it moves)
    public float amplitude = 0.5f;

    // Frequency of the wobble (how fast it moves up and down)
    public float frequency = 1f;

    // Initial position of the object
    private Vector3 startPos;

    private void Start()
    {
        // Store the initial position of the object
        startPos = transform.position;
    }

    private void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;

        // Apply the new position to the object
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
