using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public Animator animator;
   
    void Update()
    {
        if(Keyboard.current.xKey.wasPressedThisFrame)
        {
            animator.SetTrigger("shoot");
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }
}
