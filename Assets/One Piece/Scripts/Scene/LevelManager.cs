using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        // Lock or unlock levels based on player progress
        UnlockLevels();
    }

    void UnlockLevels()
    {
        int completedLevels = PlayerPrefs.GetInt("CompletedLevels", 0);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            bool isLevelUnlocked = i <= completedLevels;
            levelButtons[i].interactable = isLevelUnlocked;
        }
    }

    // Call this function when the player touches the flag to complete the level
    public void CompleteLevel(int level)
    {
        int completedLevels = PlayerPrefs.GetInt("CompletedLevels", 0);

        if (level == completedLevels + 1)
        {
            completedLevels++;
            PlayerPrefs.SetInt("CompletedLevels", completedLevels);

            // Update the UI to reflect the unlocked level
            UnlockLevels();
        }
    }
}
