using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MeleeHealth : MonoBehaviour
{
    public int enemyHealth;
    public NavMeshAgent agent;
    public MeleeEnemyBehavior meB;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            anim.SetBool("isDead", true);
            agent.speed = 0;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            enemyHealth -= 50;
        }

        if (other.gameObject.tag == "IceProjectile")
        {
            StartCoroutine("freezePeriod");
            agent.speed = 0;
            meB.enabled = false;
        }
    }

    IEnumerator freezePeriod()
    {
        yield return new WaitForSeconds(5);
        agent.speed = 6;
        meB.enabled = true;
    }

    void death()
    {
        Destroy(gameObject);
    }
}

