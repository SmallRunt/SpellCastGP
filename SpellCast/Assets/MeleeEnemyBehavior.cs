using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MeleeEnemyBehavior : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject targetPlayer;
    public float attackTimer;
    public Animator anim;
    public playerHealth pH;
    public bool isChase = false;
    // Start is called before the first frame update
    void Start()
    {
        
        attackTimer = 3;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (agent.speed == 7)
        //{
        //    anim.SetBool("isWalking", true);
        //}

        //if (agent.speed == 0)
        //{
        //    anim.SetBool("isWalking", false);
        //}

        float distanceFromPlayer = Vector3.Distance(targetPlayer.transform.position, transform.position);
        if (distanceFromPlayer <= 10)
        {
            isChase = true;
           
        }

        if (isChase)
        {
            ChasePlayer();
        }

        if (distanceFromPlayer <= agent.stoppingDistance)
        {
            attackTimer -= 1 * Time.deltaTime;
            
        }

        if (attackTimer == 2)
        {
            //anim.SetBool("isWalking", true);
        }

        if (attackTimer <= 0)
        {
            anim.SetBool("isAttacking", true);
            attackTimer = 0;
            transform.LookAt(targetPlayer.transform.position);          
            
        }
    }

    private void ChasePlayer()
    {
        
        float distanceFromPlayer = Vector3.Distance(targetPlayer.transform.position, transform.position);

        agent.SetDestination(targetPlayer.transform.position);
        if (distanceFromPlayer <= agent.stoppingDistance)
        {
            agent.speed = 0;
            FaceTarget(targetPlayer.transform);
        }

        if (distanceFromPlayer >= 5)
        {
            attackTimer = 2;
            anim.SetBool("isAttacking", false);
            agent.speed = 7;
        }
    }


    void FaceTarget(Transform target)
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToTarget.x, 0, directionToTarget.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void attackPlayer()
    {
        pH.pHealth -= 10;
    }

}
