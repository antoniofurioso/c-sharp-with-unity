using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce ;
    private float gravityModifier = 1.5f;
    private float yUp = 14.14f;
    public bool isLowEnough;
    public bool isOnGround = false;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb = GetComponent<Rigidbody>();
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < yUp)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
            isLowEnough = true;
        }else if (transform.position.y > yUp)
        {
            playerRb.AddForce(Vector3.down * 3, ForceMode.Impulse);
            transform.position = new Vector3(transform.position.x, yUp, transform.position.z);
            isLowEnough = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        else if (other.gameObject.CompareTag("Ground") && playerRb.transform.position.y < 4)
        {
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            isOnGround = true;
            playerAudio.PlayOneShot(bounceSound, 1.0f);
        }

    }

}
