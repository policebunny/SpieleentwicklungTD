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
    public Path thePath;
    //jic i want to disable spawns
    public bool shouldSpawn = true;

    public float waveDisplayTime;
    private float waveDisplayCounter;
    private int waveCounter;

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = waitForFirstSpawn;
        waveCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldSpawn)
        {
            spawnCounter -= Time.deltaTime;
            if(spawnCounter <= 0)
            {
                if(wavesToSpawn[0].shouldDisplayWave)
                {
                    wavesToSpawn[0].shouldDisplayWave = false;

                    //UIController.instance.waveText.gameObject.SetActive(true);
                    //UIController.instance.waveText.text = "Wave " + waveCounter;
                    waveDisplayCounter = waveDisplayTime;
                }

                if(wavesToSpawn.Count > 0)
                {
                    if(wavesToSpawn[0].enemySpawnOrder.Count > 0)
                    {
                        Instantiate(wavesToSpawn[0].enemySpawnOrder[0], spawnPoint.position, spawnPoint.rotation).Setup(theCastle, thePath);

                        spawnCounter = wavesToSpawn[0].timeBetweenSpawns;

                        wavesToSpawn[0].enemySpawnOrder.RemoveAt(0);
                        if(wavesToSpawn[0].enemySpawnOrder.Count == 0)
                        {
                            spawnCounter = wavesToSpawn[0].timeToNextWave;

                            wavesToSpawn.RemoveAt(0);
                            waveCounter++;

                            if(wavesToSpawn.Count == 0)
                            {
                                //disables spawn
                                shouldSpawn = false;
                            }
                        }
                    }
                }
            }
        }

        if(waveDisplayCounter > 0)
        {
            waveDisplayCounter -= Time.deltaTime;
            if(waveDisplayCounter <= 0)
            {
                UIController.instance.waveText.gameObject.SetActive(false);
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
