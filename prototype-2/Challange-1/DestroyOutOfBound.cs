using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBounce = 30;
    private float bottomBounce = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if an animal pass the farmer destroy the animal
        if(transform.position.z > topBounce)
        {
            Destroy(gameObject);
        } else if (transform.position.z < bottomBounce)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
