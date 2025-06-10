using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;

    //coin
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    //checkpoint
    public static Vector2 lastCheckPointPos = new Vector2(-6, 0);

    //ch select
    public GameObject[] playerPrefabs;
    int characterIndex;

    private void Awake()
    {
        //ch select
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);

        // Load the total coins from all levels
        numberOfCoins = PlayerPrefs.GetInt("TotalCoins", 0);


        // Reset the level-specific collected coins when starting a new level
        if (!isGameOver)
        {
            // Do not reset total coins, only reset the collected coins for the current level
            numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        }
    }

    void Update()
    {
        coinsText.text = numberOfCoins.ToString();

        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            //AudioManager.instance.Play("gameove");
        }
    }

    public void ReplayLevel()
    {
        isGameOver = false;

        // Reset the collected coins for the current level
        numberOfCoins = 0;
        PlayerPrefs.SetInt("NumberOfCoins", numberOfCoins);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        // Save the total collected coins before going to the menu
        //PlayerPrefs.SetInt("TotalCoins", numberOfCoins + PlayerPrefs.GetInt("TotalCoins", 0));

        SceneManager.LoadScene("NewMenu");
        
    }
}
 