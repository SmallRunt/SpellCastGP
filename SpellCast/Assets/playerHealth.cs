using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerHealth : MonoBehaviour
{
    public float pHealth= 100;
    public int pEnergy = 100;
    public int damageTaken = 50;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = pHealth;
        
        if(pHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyProjectile")
        {
            pHealth -= damageTaken;
        }

        if (other.gameObject.tag == "CommonProjectile")
        {
            pHealth -= damageTaken;
        }

        if (other.gameObject.tag == "BossProjectile2")
        {
            pHealth -= 90;
        }

        if (other.gameObject.tag == "Tail")
        {
            pHealth -= 30;
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "FireWall")
        {
            pHealth -= 0.5f;
        }
    }
}
