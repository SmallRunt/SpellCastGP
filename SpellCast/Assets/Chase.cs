using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : StateMachineBehaviour
{
    public float speed = 4;
    private Quaternion lookRotation;
    public Transform playerPos;
    public Transform bossPos;
    private int rand;
    public float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);

        if (rand == 0)
        {
            animator.SetTrigger("FireballShoot");
        }

        else
        {
            animator.SetTrigger("TailAttack");
        }

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bossPos = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        Vector3 target = new Vector3(playerPos.transform.position.x,playerPos.transform.position.y, playerPos.transform.position.z);
        bossPos.transform.rotation = Quaternion.Slerp(bossPos.transform.rotation,playerPos.transform.rotation, Time.deltaTime * 5);
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
