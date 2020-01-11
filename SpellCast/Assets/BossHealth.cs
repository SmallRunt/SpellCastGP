using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealth : MonoBehaviour
{
    public float bossHealth;
    public Slider bossHealthbar;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bossHealthbar.value = bossHealth;

        if (bossHealth <= 100)
        {
            anim.SetTrigger("Stage2");
        }

        if (bossHealth <= 0)
        {
            anim.SetTrigger("Death");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            anim.SetTrigger("isHit");
            bossHealth -= 50;
        }
    }
}
