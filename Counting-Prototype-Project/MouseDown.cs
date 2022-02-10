using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDown : MonoBehaviour
{
    [SerializeField] Rigidbody balls;
    [SerializeField] float forceBall = 20;

    // Start is called before the first frame update
    void Start()
    {
        balls = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0.30f)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        balls.AddForce(Vector3.left * forceBall, ForceMode.Impulse);
        balls.AddForce(Vector3.up * forceBall, ForceMode.Impulse);
    }

}
