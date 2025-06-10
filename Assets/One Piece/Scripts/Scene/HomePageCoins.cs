using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomePageCoins : MonoBehaviour
{
    public TextMeshProUGUI totalCoinsText;

    void Start()
    {
        // Retrieve and display the total collected coins
        UpdateTotalCoinsText();
    }

    // This function can be called whenever you need to update the displayed total coins
    public void UpdateTotalCoinsText()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        totalCoinsText.text = totalCoins.ToString();
    }
}
