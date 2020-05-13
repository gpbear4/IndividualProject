using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour
{
    public float verSpeed = 20;
    public float hozSpeed = 10;
    public AudioClip squishSound;
    private AudioSource audioSource;
    public bool gameOver = false;
    public ParticleSystem expParticle;
    public GameObject powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        // Here is my comment
        transform.Translate(Vector3.forward * Time.deltaTime * verSpeed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * hozSpeed * horizontalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * hozSpeed * horizontalInput);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // game over if the player hits an obstacle
        if (collision.gameObject.CompareTag("Enemy"))
        {
            expParticle.Play();
            gameOver = true;
            Debug.Log("Game Over!");
            audioSource.PlayOneShot(squishSound, 1.0f);
            //Destroy(gameObject);
        }
        // set on ground state to true if we hit the ground
    }
}
