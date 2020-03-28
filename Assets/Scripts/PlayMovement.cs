using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour
{
    public float verSpeed = 20;
    public float hozSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
