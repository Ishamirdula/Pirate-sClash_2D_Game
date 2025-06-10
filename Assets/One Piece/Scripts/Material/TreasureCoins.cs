using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCoins : MonoBehaviour
{
    public int coinsToAdd = 10; // Set the number of coins to add in the Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerManager.numberOfCoins += coinsToAdd;
            PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);
        }
    }

}
