using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Arrays for Enemies")]
    public GameObject[] enemies; 

    [Header("Arrays for Elite Enemies")]
    public GameObject[] eliteEnemies; 

    [Header("Arrays for Boss Enemies")]
    public GameObject[] bossEnemies;  

    [Header("Arrays for Spawnpoints")]
    public Transform[] spawnPoints; 

    [Header("Enemy Count")]
    public int enemyCount; 
    public int maxEnemyCount; 

    [Header("Enemy Spawning")]
    public float spawnTime; 
    public float spawnDelay; 

    [Header("Wave Count")]
    public int waveCount;   

    private int spawnAmount;  

    [Header("Elite Spawning")]
    public int eliteChance; 
    public int elitesToSpawn; 
    public int maxEliteCount; 

    [Header("Spawning Flags")]
    private bool isSpawning; 
    private bool spawningElites; 

    void Start()
    {
        // Start spawning enemy waves
        StartCoroutine(SpawnEnemyWave(waveCount));

        // Set the initial values for regular enemies
        isSpawning = false;
        waveCount = 0;
        maxEnemyCount = 1;
        spawnAmount = maxEnemyCount;

        // Set the initial values for elite enemies
        spawningElites = false;
        maxEliteCount = 0;
        eliteChance = 1;
        elitesToSpawn = 0;

        // Set the spawn time and delay for each wave of enemies
        spawnTime = 3;
        spawnDelay = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the enemy count
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // Check if all enemies are defeated and not currently spawning
        if (enemyCount == 0 && !isSpawning)
        {
            // Check if the current wave count is less than or equal to the maximum enemy count
            if (waveCount <= maxEnemyCount)
            {
                // Increase the wave count, maximum enemy count, elite chance, and spawn amount
                waveCount++;
                maxEnemyCount += 1;
                eliteChance += 1;
                spawnAmount = maxEnemyCount;

                // Spawn the enemies
                SpawnEnemies();
            }
            // Check if the maximum enemy count has reached 25
            else if (maxEnemyCount == 25)
            {
                // Spawn the enemies
                SpawnEnemies();
            }
        }
    }

    // Spawns regular enemies and elite enemies
    public void SpawnEnemies()
    {
        // Check if the current wave count is less than or equal to 25
        if (waveCount >= 25)
        {
            // Spawn boss enemies
            StartCoroutine(SpawnBoss());
            return;
        }
        else
        {
            // Spawn elite enemies
            SpawnElites();
            StartCoroutine(SpawnEnemyWave(waveCount));
        }
    }

    // Spawns elite enemies
    void SpawnElites()
    {
        // Calculate the maximum number of elite enemies that can be spawned
        maxEliteCount = spawnAmount / 5;

        // Randomly determine if elite enemies should be spawned based on elite chance
        int didSpawnElite = Random.Range(0, 100);

        if (didSpawnElite < eliteChance)
        {
            spawningElites = true;
        }
        else
        {
            spawningElites = false;
        }

        // Spawn elite enemies if the flag is set to true
        if (spawningElites == true)
        {
            // Randomly determine the number of elite enemies to spawn
            elitesToSpawn = Random.Range(1, maxEliteCount);

            // Adjust the spawn amount by subtracting the number of elite enemies to spawn
            spawnAmount -= elitesToSpawn;

            // Start spawning elite enemies
            StartCoroutine(SpawningElites(elitesToSpawn));
        }
    }

    // Coroutine for spawning regular enemies
    IEnumerator SpawnEnemyWave(int enemySpawn)
    {
        isSpawning = true;

        // Adjust the enemy spawn count based on the spawn amount
        enemySpawn -= (enemySpawn - spawnAmount);

        yield return new WaitForSeconds(spawnTime);

        // Spawn the regular enemies
        for (int i = 0; i < enemySpawn; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, enemies[Random.Range(0, enemies.Length)].transform.rotation);
            yield return new WaitForSeconds(spawnDelay);
        }

        isSpawning = false;
    }

    // Coroutine for spawning elite enemies
    IEnumerator SpawningElites(int eliteSpawn)
    {
        yield return new WaitForSeconds(spawnTime);

        // Spawn the elite enemies
        for (int i = 0; i < eliteSpawn; i++)
        {
            Instantiate(eliteEnemies[Random.Range(0, eliteEnemies.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, eliteEnemies[Random.Range(0, eliteEnemies.Length)].transform.rotation);
            yield return new WaitForSeconds(spawnDelay);

            spawningElites = false;
        }
    }

    // Coroutine for spawning boss enemies
    IEnumerator SpawnBoss()
    {
        isSpawning = true;
        yield return new WaitForSeconds(spawnTime);

        // Spawn the boss enemy
        Instantiate(bossEnemies[Random.Range(0, bossEnemies.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, bossEnemies[Random.Range(0, bossEnemies.Length)].transform.rotation);

        // Spawn elite enemies
        SpawnElites();

        // Start spawning regular enemies
        StartCoroutine(SpawnEnemyWave(spawnAmount));

        yield return new WaitForSeconds(spawnDelay);
        isSpawning = false;
    }
}
