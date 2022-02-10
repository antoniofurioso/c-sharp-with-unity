using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject prefabBalls;
    private float spawnZPos = 1.5f;
    private float ballsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBallsWave();
        InvokeRepeating("SpawnBallsWave", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawn some enemy in random position
   private void SpawnBallsWave()
    {
        Instantiate(prefabBalls, SpawnManagerPos(), prefabBalls.transform.rotation);
    }

    //Spawn different things in random position
    public Vector3 SpawnManagerPos()
    {
        float spawnPosX = Random.Range(13, 16);
        float spawnPosZ = Random.Range(-spawnZPos, spawnZPos);

        Vector3 randomPosition = new Vector3(spawnPosX, 1, spawnPosZ);

        return randomPosition;
    }
}
