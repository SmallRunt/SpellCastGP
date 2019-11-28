using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject rHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            rHand.transform.position += Vector3.left;
        }
        Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
        newPos.z = transform.position.z;

        rHand.transform.position = newPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MagicTome")
        {
            Debug.Log("Yes");
        }
    }
}
