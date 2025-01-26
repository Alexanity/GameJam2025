using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    // Coordinates to teleport the player to
    public Vector3 teleportCoordinates;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the collider has the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (other.gameObject == player)
        {
            // Teleport the Player to the specified coordinates
            player.transform.position = teleportCoordinates;
        }
    }
}