using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalsPrefabs;
    private float spawnX = 10;
    private float spawnZ = 20;
    private float startDelay =2;
    private float spawnInterval = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnRandomAnimal ()
    {
        int animalIndex = Random.Range(0, animalsPrefabs.Length);
        Vector3 spawnRange = new Vector3 (Random.Range(-spawnX, spawnX), 0, spawnZ);

        Instantiate(animalsPrefabs[animalIndex], spawnRange, animalsPrefabs[animalIndex].transform.rotation);
    }
}
