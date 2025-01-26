using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private Canvas interactionCanvas; // Canvas to display when the player enters
    [SerializeField] private int bubbleId;
    [SerializeField] private Renderer renderer;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Collider bubbleCollider;
    private bool isPlayerInZone = false; // Tracks if the player is in the trigger zone


    private BubbleStateManager stateManager;

    private Vector3 startingPosition;
    private Vector3 targetPosition;

    private bool canMove = false;
    private bool canInteract = false;

    //private Color originalColor;
    //private Color activeColor = Color.green;

    [SerializeField] private GameObject cube;

    private void Start()
    {
        if (interactionCanvas != null)
        {
            interactionCanvas.enabled = false;
        }
        startingPosition = transform.position;

        if (cube != null)
        {
            targetPosition = cube.transform.position;
        }
        else
        {
            Debug.LogError("Cube not assigned to Bubble!");
        }

        //if (renderer != null)
        //{
        //    originalColor = renderer.material.color;
        //}

        if (bubbleCollider == null)
        {
            bubbleCollider = GetComponent<Collider>();
        }

        stateManager = FindObjectOfType<BubbleStateManager>();
        if (stateManager == null)
        {
            Debug.LogError("BubbleStateManager not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;

            // Show the canvas
            if (interactionCanvas != null)
            {
                interactionCanvas.enabled = true;
            }
        }
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            Debug.Log($"Player entered bubble {bubbleId}'s interaction zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;

            // Hide the canvas
            if (interactionCanvas != null)
            {
                interactionCanvas.enabled = false;
            }
        }
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            Debug.Log($"Player exited bubble {bubbleId}'s interaction zone.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canInteract)
        {
            Interact();
        }

        if (canMove)
        {
            MoveTowardsTarget();
        }
    }

    private void Interact()
    {
        if (stateManager != null)
        {
            stateManager.CheckOrder(bubbleId);
        }
    }

    public void SetState(bool isActive)
    {
        //if (renderer != null)
        //{
        //    renderer.material.color = isActive ? activeColor : originalColor;
        //}

        if (isActive)
        {
            StartMovement();
        }
        else
        {
            ResetPosition();
        }
    }

    private void StartMovement()
    {
        canMove = true;
    }

    private void ResetPosition()
    {
        transform.position = startingPosition;
        canMove = false;
        ShowBubble();
    }

    private void MoveTowardsTarget()
    {
        FindObjectOfType<AudioManager>().Play(""); // Bubble interact success
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            canMove = false;
            HideBubble();
            Debug.Log($"Bubble {bubbleId} reached the cube.");
        }
    }

    private void HideBubble()
    {
        renderer.enabled = false;
        bubbleCollider.enabled = false;
    }

    private void ShowBubble()
    {
        renderer.enabled = true;
        bubbleCollider.enabled = true;
    }
}