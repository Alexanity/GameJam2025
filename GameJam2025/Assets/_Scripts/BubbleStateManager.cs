using System.Collections.Generic;
using UnityEngine;

public class BubbleStateManager : MonoBehaviour
{
    [SerializeField] private int[] triggerOrder = { 0, 1, 2, 3 };
    private int currentTrigger = 0;

    [SerializeField] private List<Bubble> bubbles;

    [SerializeField] private GameObject cube;

    [Tooltip("The object to enable when the puzzle is successfully solved.")]
    [SerializeField] private GameObject objectToEnable;
    [SerializeField] private GameObject FinalSceneTransition;
    [SerializeField] private GameObject secondObjectToEnable;

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
        FindObjectOfType<AudioManager>().Play("BubbleFail");
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
        EnableObject();
        EnableSecondObject();
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
            Debug.Log("Cube has disappeared!");
        }
    }

    private void EnableObject()
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
            FindObjectOfType<AudioManager>().Play("PortalOpen");
            FindObjectOfType<AudioManager>().Play("PortalAmbiance");
            Debug.Log($"{objectToEnable.name} has been enabled!");
        }
        else
        {
            Debug.LogWarning("Object to enable is not assigned in the editor.");
        }
    }
    private void EnableSecondObject()
    {
        if (secondObjectToEnable != null)
        {
            secondObjectToEnable.SetActive(true);
            Debug.Log($"{secondObjectToEnable.name} has been enabled!");
        }
        else
        {
            Debug.LogWarning("Object to enable is not assigned in the editor.");
        }

        if (FinalSceneTransition != null)
        {
            FinalSceneTransition.SetActive(true);
            Debug.Log($"{FinalSceneTransition.name} has been enabled!");
        }
        else
        {
            Debug.LogWarning("Object to enable is not assigned in the editor.");
        }
    }
}
