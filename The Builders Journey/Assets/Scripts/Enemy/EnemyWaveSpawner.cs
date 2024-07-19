using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public List<EnemyWave> wavesToSpawn;
    //keep track of time between encounter
    private float spawnCounter;
    public float waitForFirstSpawn;

    public Transform spawnPoint;

    public Castle theCastle;
    public int index = 0;
    public Path thePath;
    //jic i want to disable spawns
    public bool shouldSpawn = true;

    public float waveDisplayTime;
    private float waveDisplayCounter;
    private int waveCounter;
    private float timer = 15;
    private float timermax = 20f;
    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = waitForFirstSpawn;
        waveCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (shouldSpawn && timer > timermax)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                if (wavesToSpawn[waveCounter].shouldDisplayWave)
                {
                    wavesToSpawn[waveCounter].shouldDisplayWave = false;

                    //UIController.instance.waveText.gameObject.SetActive(true);
                    //UIController.instance.waveText.text = "Wave " + waveCounter;
                    waveDisplayCounter = waveDisplayTime;
                }

                if (wavesToSpawn.Count > 0)
                {
                    if (wavesToSpawn[waveCounter].enemySpawnOrder.Count > 0)
                    {
                        Instantiate(wavesToSpawn[waveCounter].enemySpawnOrder[index], spawnPoint.position, spawnPoint.rotation).Setup(theCastle, thePath);
                        index++;
                        spawnCounter = wavesToSpawn[waveCounter].timeBetweenSpawns;
                        if (wavesToSpawn[waveCounter].enemySpawnOrder.Count == index)
                        {
                            spawnCounter = wavesToSpawn[waveCounter].timeToNextWave;
                            waveCounter++;

                            if (wavesToSpawn.Count == waveCounter)
                            {
                                index = 0;
                                timer = 0;
                                waveCounter = 0;
                                //disables spawn
                                //shouldSpawn = false;
                            }
                        }
                    }
                }
            }
        }

        if (waveDisplayCounter > 0)
        {
            waveDisplayCounter -= Time.deltaTime;
            if (waveDisplayCounter <= 0)
            {
                //UIController.instance.waveText.gameObject.SetActive(false);
            }
        }
    }
}
//keep track of enemies, sets spawn between time and between waves
[System.Serializable]
public class EnemyWave
{
    public List<EnemyController> enemySpawnOrder = new List<EnemyController>(0);
    public float timeBetweenSpawns;
    public float timeToNextWave;
    [HideInInspector]
    public bool shouldDisplayWave = true;
}
