using UnityEngine;

public class LockMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Lock and hide the mouse cursor when the scene starts
        LockMouseCursor();
    }

    // Lock the mouse cursor and hide it
    public void LockMouseCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen
        Cursor.visible = false; // Hides the cursor
    }

    // Unlock the mouse cursor and make it visible again (if needed)
    public void UnlockMouseCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Unlocks the cursor
        Cursor.visible = true; // Makes the cursor visible
    }
}
