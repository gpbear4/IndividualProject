using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private int seconds = 0;
    private TextMeshProUGUI textMesh;
    private SpawnManager spawnManager;
    public GameObject waterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        spawnManager = waterSpawn.GetComponent<SpawnManager>();
        textMesh.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startTimer()
    {
        StartCoroutine(updateSeconds());
    }
    IEnumerator updateSeconds()
    {
        while(spawnManager.gameActive)
        {
            textMesh.text = "Timer: " + seconds;
            seconds++;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
