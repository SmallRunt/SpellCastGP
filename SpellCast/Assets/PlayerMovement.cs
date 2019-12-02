using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float movespeed = 5;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * movespeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = transform.right * -movespeed;
        }

        
    }
}
