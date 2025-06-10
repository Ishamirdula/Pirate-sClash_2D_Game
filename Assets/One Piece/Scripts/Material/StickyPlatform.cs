using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "luffy")
        {
            collision.gameObject.transform.SetParent(transform);

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "luffy")
        {
            collision.gameObject.transform.SetParent(null);

        }
    } */

    private bool isCollisionOnTop(Collision2D collision)
    {
        Vector3 contactNormal = collision.GetContact(0).normal;
        float angle = Vector3.Angle(contactNormal, Vector3.up);

        return Mathf.Approximately(angle, 180);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "luffy" && isCollisionOnTop(collision))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

}
