using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Attacker"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
