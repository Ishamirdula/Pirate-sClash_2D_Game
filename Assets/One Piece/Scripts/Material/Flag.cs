using UnityEngine;

public class Flag : MonoBehaviour
{
    public int levelNumber = 1; // Set this in the inspector for each flag
    public GameObject panel;    // Reference to the UI Panel

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // the player touched the flag 
            panel.SetActive(true);

            // Play audio when the panel is opened
            AudioManager.instance.Play("gamecom");

            // Complete the level and unlock the next level
            CompleteLevel();
        }
    }

    void CompleteLevel()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.CompleteLevel(levelNumber);
    }
}
