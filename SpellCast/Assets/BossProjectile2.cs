using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile2 : MonoBehaviour
{
    public GameObject RingFire;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            FireWall();
        }
    }

   void FireWall()
    {
        Instantiate(RingFire, transform.position, transform.rotation);
    }

  
}
