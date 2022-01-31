using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject powerup;
    public GameObject player;

    private float spawnPosition = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        GeneratePowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0 && player.transform.position.y > -6)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            GeneratePowerup();
        }

    }

    // We are generating a powerup
    void GeneratePowerup()
    {
        Instantiate(powerup, SpawnManagerPos(), powerup.transform.rotation);
    }

    //Spawn some enemy in random position
    private void SpawnEnemyWave(int enemytoSpawn)
    {
        for (int i = 0; i < enemytoSpawn; i++)
        {
            Instantiate(enemy, SpawnManagerPos(), enemy.transform.rotation);
        }
    }


    //Spawn different things in random position
    private Vector3 SpawnManagerPos()
    {
        float spawnPosX = Random.Range(-spawnPosition, spawnPosition);
        float spawnPosZ = Random.Range(-spawnPosition, spawnPosition);

        Vector3 randomPosition = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPosition;
    }
}
