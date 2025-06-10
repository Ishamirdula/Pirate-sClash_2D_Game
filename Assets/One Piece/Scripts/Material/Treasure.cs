using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Treasure : MonoBehaviour
{
    private void Start()
    {
        // Ensure the collider is enabled at the start
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Optionally, you can handle additional actions when the player touches the treasure
            Debug.Log("Player touched the treasure!");
        }
    }
}

