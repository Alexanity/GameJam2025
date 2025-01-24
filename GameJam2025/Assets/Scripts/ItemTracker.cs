using UnityEngine;

public class ItemTracker : MonoBehaviour
{
    [SerializeField] private GameObject item1; // First item to track
    [SerializeField] private GameObject item2; // Second item to track
    [SerializeField] private GameObject targetItem; // Item to make appear/disappear
    [SerializeField] private bool makeTargetDisappear = true; // True = Target disappears, False = Target appears

    void Update()
    {
        // Check if both items are deactivated
        if ((item1 == null || !item1.activeSelf) && (item2 == null || !item2.activeSelf))
        {
            // Perform the action on the target item
            if (targetItem != null)
            {
                targetItem.SetActive(!makeTargetDisappear); // Toggle target visibility
            }

            // Optional: Disable this script to stop repeated checks
            enabled = false;
        }
    }
}
