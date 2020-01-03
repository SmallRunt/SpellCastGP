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

    //public int enemyHealth;
    //public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        attackTimer = 3;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();

        float distanceFromPlayer = Vector3.Distance(targetPlayer.transform.position, transform.position);
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

        //if (enemyHealth <= 0)
        //{
        //    anim.SetFloat("death", 0);
        //    Instantiate(deathEffect, transform.position, transform.rotation);
        //    Destroy(gameObject, 1f);
        //}
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Projectile")
    //    {
    //        anim.SetBool("isDamage", true);
    //        enemyHealth -= 50;
    //    }
    //}

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

