using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuffyMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private Transform hitBox; // Reference to the hitBox GameObject

    private NPC_Controller npc;


    [SerializeField] private LayerMask JumpableGround;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;


    private enum MovementState { bounce, run, jump, fall }


    // Start is called before the first frame update

    private void Start()

    {

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        hitBox = transform.Find("hitBox"); // hitBox GameObject

    }



    



    private void Update()

    {
        if (!InDialogue())
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            dirX = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            
                
            

            if (Input.GetButtonDown("Jump") && IsGrounded())

            {

                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                


            }

            UpdateAnimationState();

            // Rotate hitBox based on PLayer's direction
            if (dirX > 0f)
            {
                hitBox.localScale = new Vector3(1f, 1f, 1f);
                
            }
            else if (dirX < 0f)
            {
                hitBox.localScale = new Vector3(-1f, 1f, 1f);
                
            }
        }




    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.bounce;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
           
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }

    private bool InDialogue()
    {
        if (npc != null)
            return npc.DialogueActive();
        else
            return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            npc = collision.gameObject.GetComponent<NPC_Controller>();

            if (Input.GetKey(KeyCode.E))
                npc.ActivateDialogue();

         
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Treasure"))
        {
            // Trigger the treasure animation
            other.GetComponent<Animator>().SetTrigger("OpenTreasure");
            // Play the audio when the player collects coins
            AudioManager.instance.Play("treasure");

            // Optionally, you can disable the collider to prevent repeated triggering
            other.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
