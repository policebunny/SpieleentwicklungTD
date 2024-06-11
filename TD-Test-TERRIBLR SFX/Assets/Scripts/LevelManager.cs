using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    public bool levelActive;

    private int gameover;
    private bool levelVictory;

    private Castle[] theCastles;

    public List<EnemyHealthController> activeEnemies = new List<EnemyHealthController>();

    //private SimpleEnemySpawner enemySpawner;
    private EnemyWaveSpawner[] waveSpawners;

    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        theCastles = FindObjectsOfType<Castle>();
        //enemySpawner = FindObjectOfType<SimpleEnemySpawner>();
        waveSpawners = FindObjectsOfType<EnemyWaveSpawner>();

        levelActive = true;

        gameover = 0;

        Debug.Log("Gameover set auf" + gameover);


        //AudioManager.instance.PlayBGM();
    }

    // Update is called once per frame
    void Update()
    {
        theCastles = FindObjectsOfType<Castle>();
        //enemySpawner = FindObjectOfType<SimpleEnemySpawner>();
        waveSpawners = FindObjectsOfType<EnemyWaveSpawner>();

        levelActive = true;


        if (levelActive)
        {
            float totalCastleHealth = 0;
            foreach (Castle cast in theCastles)
            {
                totalCastleHealth += cast.currentHealth;
            }

            if (totalCastleHealth <= 0 && gameover == 0)
            {
                levelActive = false;
                levelVictory = false;
                gameover = 1;

                Debug.Log("Gameover Loop");


                UIController.instance.towerButtons.SetActive(false);

            }

            bool wavesComplete = true;
            foreach (EnemyWaveSpawner wavespawn in waveSpawners)
            {
                if (wavespawn.wavesToSpawn.Count > 0)
                {
                    wavesComplete = false;
                }
            }

            if (activeEnemies.Count == 0 && wavesComplete)
            {
                //levelActive = false;
                levelVictory = true;


                UIController.instance.towerButtons.SetActive(false);
            }

            if (!levelActive)
            {

                UIController.instance.levelFailScreen.SetActive(!levelVictory);
                UIController.instance.levelCompleteScreen.SetActive(levelVictory);

                UIController.instance.CloseTowerUpgradePanel();
            }
        }

        if (gameover == 1)
        {
            AudioManager.Instance.PlayUI("Gameover");
            AudioManager.Instance.StopMusic();

            gameover = 2;
            Debug.Log("Gameover");
        }

    }
}
