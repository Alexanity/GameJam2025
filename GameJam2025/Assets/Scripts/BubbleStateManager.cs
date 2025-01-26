using System.Collections.Generic;
using UnityEngine;

public class BubbleStateManager : MonoBehaviour
{
    [SerializeField] private int[] triggerOrder = { 0, 1, 2, 3 };
    private int currentTrigger = 0;

    [SerializeField] private List<Bubble> bubbles;

    [SerializeField] private GameObject cube;

    public void CheckOrder(int bubbleId)
    {
        if (bubbleId == triggerOrder[currentTrigger])
        {
            Debug.Log($"Bubble {bubbleId} triggered correctly.");
            currentTrigger++;
            UpdateBubbleState(bubbleId, true);

            
            if (currentTrigger == triggerOrder.Length)
            {
                TriggerSuccessEvent();
            }
        }
        else
        {
            Debug.Log($"Bubble {bubbleId} triggered incorrectly. Resetting puzzle.");
            ResetPuzzle();
        }
    }

    private void ResetPuzzle()
    {
        currentTrigger = 0;
        foreach (var bubble in bubbles)
        {
            bubble.SetState(false);
        }
        FindObjectOfType<AudioManager>().Play(""); // ADD YOU STUPID AUDIO
        Debug.Log("Puzzle reset.");
    }

    private void UpdateBubbleState(int bubbleId, bool isActive)
    {
        if (bubbles != null && bubbleId < bubbles.Count)
        {
            bubbles[bubbleId].SetState(isActive);
        }
    }

    private void TriggerSuccessEvent()
    {
        HideCube();
    }

    private void HideCube()
    {
        if (cube != null)
        {
            Renderer cubeRenderer = cube.GetComponent<Renderer>();
            Collider cubeCollider = cube.GetComponent<Collider>();

            if (cubeRenderer != null)
            {
                cubeRenderer.enabled = false;
            }

            if (cubeCollider != null)
            {
                cubeCollider.enabled = false;
            }
            FindObjectOfType<AudioManager>().Play(""); // POP BUBBLE

            Debug.Log("Cube has disappeared!");
        }
    }
}
