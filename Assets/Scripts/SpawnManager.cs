using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] waterdrop;
    private const float xRange = 10;
    private const float zRange = 10;
    private const float spawnPointZ = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnWater", 1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnWater()
    {
        int randomwater = Random.Range(0, waterdrop.Length);
        Instantiate(waterdrop[randomwater], new Vector3(Random.Range(-xRange, xRange), 25, Random.Range(-zRange, zRange)), waterdrop[randomwater].transform.rotation);
    }

}
