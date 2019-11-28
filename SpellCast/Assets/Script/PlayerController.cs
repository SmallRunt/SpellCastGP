using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject rHand;
    public ParticleSystem handVFX;
    public GameObject firePrefab;
    public float spellCount;
    
    // Start is called before the first frame update
    void Start()
    {
        spellCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
        newPos.z = transform.position.z;

        rHand.transform.position = newPos;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(transform.position, fwd * 50, Color.red, 0f);

        if (Input.GetButtonDown("Fire1") && spellCount >= 1)
        {
            GameObject fireBall = Instantiate(firePrefab, rHand.transform.position, transform.rotation);
            Destroy(fireBall, 1.5f);
            spellCount -= 1;
        }

        else
        {
            return;
        }

        if (spellCount <= 0)
        {
            handVFX.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MagicTome")
        {
            spellCount =+ 1;

            if (spellCount >= 1)
            {
                handVFX.gameObject.SetActive(true);
            }

            
        }
    }
}
