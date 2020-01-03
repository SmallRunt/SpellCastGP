using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float countdown = 8;

    [System.Serializable]
    public struct WaveSystem
    {
        public List<GameObject> EnemySpawn;
    }

    public List<GameObject> enemySpawn;

    public bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!canSpawn)
        {
           countdown -= Time.deltaTime * 1f;
        }
       
        if(countdown <= 0)
        {
            countdown = 8;
            SpawnEnemy();
            canSpawn = false;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemySpawn[0], transform.position, transform.rotation);
        enemySpawn.RemoveAt(0);
    }
}
