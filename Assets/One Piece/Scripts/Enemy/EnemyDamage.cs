using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : StateMachineBehaviour
{
    // The distance the enemy should move back when damaged
    public float moveBackDistance = 2f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move the enemy back after playing the damage animation
        Vector3 currentPosition = animator.transform.position;

        // Adjust the movement direction based on the current facing direction
        float moveDirection = animator.transform.localScale.x;
        float moveBackDistanceX = moveBackDistance * moveDirection;

        Vector3 moveBackPosition = currentPosition - new Vector3(moveBackDistanceX, 0f, 0f);
        animator.transform.position = moveBackPosition;
    }


    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
