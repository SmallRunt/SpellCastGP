using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int pHealth= 100;
    public int pEnergy = 100;
    public int damageTaken = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(pHealth <= 0)
        {
            print("Game is Over");
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyProjectile")
        {
            pHealth -= damageTaken;
        }
    }
}
