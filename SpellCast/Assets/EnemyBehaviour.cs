using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBehaviour : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject firePrefab;
    public GameObject targetPlayer;
    public Transform attackPos;
    public float attackTimer;
    public Animator anim;
    public bool isChase = false;
    //public int enemyHealth;
    //public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        //targetPlayer = GameObject.FindGameObjectWithTag("Player");
        attackTimer = 3;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.speed == 6)
        {
            anim.SetBool("isWalking", true);
        }

        else if(agent.speed == 0)
        {
            anim.SetBool("isWalking", false);
        }

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

        if(attackTimer == 3)
        {
            anim.SetBool("isWalking", true);
        }

        if(attackTimer <= 0)
        {
            anim.SetBool("isWalking", false);
            attackTimer = 0;
            transform.LookAt(targetPlayer.transform.position);
            attackPlayer();
            attackTimer = 3;
        }

    }

    private void ChasePlayer()
    {
        float distanceFromPlayer = Vector3.Distance(targetPlayer.transform.position, transform.position);
        
        agent.SetDestination(targetPlayer.transform.position);
        if (distanceFromPlayer <= agent.stoppingDistance)
        {
            FaceTarget(targetPlayer.transform);
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
        anim.SetBool("isAttack", true);
        Instantiate(firePrefab, attackPos.transform.position, attackPos.transform.rotation);   
    }
}

