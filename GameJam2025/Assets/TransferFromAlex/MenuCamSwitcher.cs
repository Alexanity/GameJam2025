using UnityEngine;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{
    public CameraMenuController cameraController;

    public void GoToMainMenu()
    {
        cameraController.MoveToMenu(0); // Index for Main Menu
    }

    public void GoToGuestbook()
    {
        cameraController.MoveToMenu(1); // Index for Guestbook
    }

    public void GoToGuestbookEntry()
    {
        cameraController.MoveToMenu(2); // Index for Guestbook Entry
    }
}