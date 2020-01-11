using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flychase : StateMachineBehaviour
{
    public float speed = 4;
    private Quaternion lookRotation;
    public Transform playerPos;
    public Transform bossPos;
    public float timer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bossPos = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 target = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, playerPos.transform.position.z);
        bossPos.transform.rotation = Quaternion.Slerp(bossPos.transform.rotation, playerPos.transform.rotation, Time.deltaTime * 5);
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
    }

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
