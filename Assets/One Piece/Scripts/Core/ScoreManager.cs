using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // Reference to a Text component to display the score
    public int baseScoreIncrement = 30;  // Adjustable base score increment
    private int score = 0;
    private int enemiesDefeated = 0;
    private int enemiesPerScoreIncrease = 5;  // Adjustable number of enemies before score increase

    void Start()
    {
        UpdateScoreText();
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;

        // Check if the player has defeated the required number of enemies for a score increase
        if (enemiesDefeated % enemiesPerScoreIncrease == 0)
        {
            // Adjust the base score increment as needed
            score += baseScoreIncrement * (enemiesDefeated / enemiesPerScoreIncrease);
        }
        else
        {
            score += baseScoreIncrement;
        }

        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // Update the Text component to display the current score
        scoreText.text = "Score: " + score.ToString();
    }
}


