using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollisionEvent : MonoBehaviour
{
    public Animator anim;
    public GameObject Boss;
    public Slider healthUnhide;
    public GameObject Wall;
    public GameObject WallBlock;
    // Start is called before the first frame update
    void Start()
    {
        anim = Boss.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Check");
            anim.SetBool("Intro",true);
            healthUnhide.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Wall.gameObject.SetActive(true);
            WallBlock.gameObject.SetActive(true);
        }
    }
}
