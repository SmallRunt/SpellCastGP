using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBehaviour : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject firePrefab;
    public Transform targetPlayer;
    public Transform attackPos;
    public float attackTimer;
    // Start is called before the first frame update
    void Start()
    {
        attackTimer = 3;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();

        float distanceFromPlayer = Vector3.Distance(targetPlayer.position, transform.position);
        if (distanceFromPlayer <= agent.stoppingDistance)
        {
            attackTimer -= 1 * Time.deltaTime;
        }
       
        if(attackTimer <= 0)
        {
            attackTimer = 0;
            transform.LookAt(targetPlayer);
            attackPlayer();
            attackTimer = 3;
        }
            
    }

    private void ChasePlayer()
    {
        float distanceFromPlayer = Vector3.Distance(targetPlayer.position, transform.position);

        agent.SetDestination(targetPlayer.position);
        if (distanceFromPlayer <= agent.stoppingDistance)
        {
            FaceTarget(targetPlayer);
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
        Instantiate(firePrefab, attackPos.transform.position, attackPos.transform.rotation);
        //Destroy(firePrefab, 2f);
    }
}

