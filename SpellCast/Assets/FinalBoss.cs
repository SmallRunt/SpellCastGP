using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalBoss : MonoBehaviour
{
    
    
    public GameObject FireballPrefab;
    public Transform firePos;
    public Transform playerPos;
    public Transform firePos2;
    public GameObject FireBoltPrefab;
    public AudioSource dragonRoarSFX;
    public AudioSource dragonRoarSofterSFX;
    public AudioSource dragonDeathSFX;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void dragonRoar()
    {
        dragonRoarSFX.Play();
    }

    void dragonRoarSoft()
    {
        dragonRoarSofterSFX.Play();
    }


    void dragonDeath()
    {
        dragonDeathSFX.Play();
    }

    void fireballAttack()
    {
        Instantiate(FireballPrefab, firePos.transform.position, firePos.transform.rotation);
    }

    void fireBoltAttack()
    {
        Instantiate(FireBoltPrefab, firePos2.transform.position, firePos2.transform.rotation);
    }

}
