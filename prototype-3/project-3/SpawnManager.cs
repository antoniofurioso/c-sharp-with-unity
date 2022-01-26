using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 spawnPosition = new Vector3 (16, 0, 0);
    private float startDelay = 2;
    private float repeating = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", startDelay, repeating);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles ()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
        }
    }
}
