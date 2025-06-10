using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    public int enemyHP = 100;
    public Animator animator;
    public Slider enemyHealthBar;
    public ScoreManager scoreManager;




    void Start()
    {
       

        enemyHealthBar.value = enemyHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }

    
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        
        enemyHP -= damageAmount;
        enemyHealthBar.value = enemyHP;
        if (enemyHP > 0) 
        {
            //Player get hit animation
            animator.SetTrigger("damage");
           
            
        }
        else
        {
            //player death animation
            //animator.SetTrigger("death");
            //GetComponent<CapsuleCollider2D>().enabled = false;
            //enemyHealthBar.gameObject.SetActive(false);
            //this.enabled = false;
            //Destroy(this.gameObject);
            StartCoroutine(DestroyAfterDeathAnimation());
        }

   
    }

    

    private IEnumerator DestroyAfterDeathAnimation()
    {
        

        // Trigger the death animation
        animator.SetTrigger("death");

        // Wait for the death animation to finish playing
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length + 2f);

        // Disable the collider and destroy the gameObject
        GetComponent<CapsuleCollider2D>().enabled = false;
        enemyHealthBar.gameObject.SetActive(false);
        this.enabled = false;
        this.enabled = false;
        Destroy(this.gameObject);
        // Notify the ScoreManager about the defeated enemy
        scoreManager.EnemyDefeated();
    }

    public void PlayerDamage()
    {
        if (!target.GetComponent<PlayerCollision>().isInvincible)
        {
            target.GetComponent<PlayerCollision>().TakeDamage();

        }
      

    }
}
