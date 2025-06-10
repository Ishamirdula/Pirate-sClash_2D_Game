using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStartPosition : MonoBehaviour
{
    public string playerTag = "Player";
    public string checkpointTag = "Checkpoint";

    void Start()
    {
        // Find the player GameObject by tag
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        // Check if the player GameObject is found
        if (player != null)
        {
            // Check if there is a checkpoint in the scene
            GameObject checkpoint = GameObject.FindGameObjectWithTag(checkpointTag);

            // If a checkpoint is found, set the player's position to the checkpoint position
            if (checkpoint != null)
            {
                player.transform.position = checkpoint.transform.position;
            }
            else
            {
                // If no checkpoint is found, use the level's default starting position
                SetPlayerStartPosition(player);
            }
        }
        else
        {
            Debug.LogError("Player GameObject not found. Make sure it has the correct tag.");
        }
    }

    private void SetPlayerStartPosition(GameObject player)
    {
        // Get the current level index
        int levelIndex = SceneManager.GetActiveScene().buildIndex;

        // Set the player's position based on the current level
        switch (levelIndex)
        {
            case 1:
                player.transform.position = new Vector2(-7, 1);
                break;
            case 2:
                player.transform.position = new Vector2(-11, 1);
                break;
            case 3:
                player.transform.position = new Vector2(24, 7);
                break;
            case 4:
                player.transform.position = new Vector2(22, 8);
                break;
            case 5:
                player.transform.position = new Vector2(66, 4);
                break;
            default:
                // Default position if the level is not specified
                player.transform.position = new Vector2(0, 0);
                break;
        }
    }
}
