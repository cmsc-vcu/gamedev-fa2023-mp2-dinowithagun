using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float spawnCooldownMin = 10f;
    public float spawnCooldownMax = 15f;
    public int maxEnemies = 10;
    public int enemyCount;
    private float spawnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        spawnCooldown = Random.Range(spawnCooldownMin, spawnCooldownMax);
        enemyCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnCooldown <= 0)
        {
            if (enemyCount < maxEnemies)
            {
                Vector2 spawnLocation = Random.insideUnitCircle * 15;
                Instantiate(EnemyPrefab, spawnLocation, Quaternion.identity);
            }
            spawnCooldown = Random.Range(spawnCooldownMin, spawnCooldownMax);
        }

        spawnCooldown -= Time.deltaTime;
    }
}
