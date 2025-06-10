using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuffyController : MonoBehaviour
{
    public Animator animator;

    
    void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.Z)) // OnePunch
            {
                OnePunch();
               

            }
           else if (Input.GetKeyDown(KeyCode.W)) // MultiplePunch
        {
                  MultiplePunch();
            
              }
           else if (Input.GetKeyDown(KeyCode.X)) // Kick
        {
                   Kick();

             }

    }

    void OnePunch()
    {
        animator.SetTrigger("Attack");

       
    }

    void MultiplePunch()
    {
        animator.SetTrigger("Attack1");

       
        
    }
    void Kick()
    {
        animator.SetTrigger("Attack2");

        
    }

   

}
