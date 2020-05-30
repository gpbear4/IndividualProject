using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour
{
    public GameObject endScreen;
    //public float verSpeed = 20;
    //public float hozSpeed = 10;
    public AudioClip squishSound;
    private AudioSource audioSource;
    public ParticleSystem expParticle;
    //public GameObject powerUpPrefab;
    private SpawnManager spawnManager;
    public GameObject waterSpawn;

    public float speed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spawnManager = waterSpawn.GetComponent<SpawnManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        // Here is my comment
        //transform.Translate(Vector3.forward * Time.deltaTime * verSpeed * verticalInput);
        //transform.Translate(Vector3.right * Time.deltaTime * hozSpeed * horizontalInput);
        //transform.Rotate(Vector3.up * Time.deltaTime * hozSpeed * horizontalInput);
        Vector3 movement = new Vector3 (horizontalInput, 0.0f, verticalInput);
        rb.AddForce (movement * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // game over if the player hits an obstacle
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(expParticle);
            spawnManager.gameActive = false;
            Debug.Log("Game Over!");
            audioSource.PlayOneShot(squishSound, 1.0f);
            Destroy(gameObject, 0.5f);
            endScreen.SetActive(true);
        }
        // set on ground state to true if we hit the ground
    }
}
