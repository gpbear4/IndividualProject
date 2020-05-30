using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public bool gameActive = false;
    public GameObject[] enemyarray;
    private const float xRange = 10;
    private const float zRange = 10;
    private const float spawnPointZ = 1;
    public int waveNumber = 1;
    public int enemyCount;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnHail", 1, 1);
    }

    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        gameActive = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            enemyCount = FindObjectsOfType<WaterControl>().Length;
            if (enemyCount == 0)
            {
                StartCoroutine(SpawnWater(waveNumber));
                waveNumber++;
            }
        }
    }
    IEnumerator SpawnWater(int numbDrops)
    {
        for (int i = 0; i < numbDrops; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.0f, 5.0f));
            Instantiate(enemyarray[0], new Vector3(Random.Range(-xRange, xRange), 25, Random.Range(-zRange, zRange)), enemyarray[0].transform.rotation);
        }
    }
    void SpawnHail()
    {
        if (gameActive)
        {
            Instantiate(enemyarray[1], new Vector3(Random.Range(-xRange, xRange), 25, Random.Range(-zRange, zRange)), enemyarray[1].transform.rotation);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
