using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    public bool levelActive;
    private float timer;
    private float startdelay=10f;
    private int gameover;
    private bool isRunning;
    private bool levelVictory;
    public int pathcounter=0;

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


        AudioManager.Instance.musicPlaylist = new string[] { "Ingame_1", "Ingame_2", "Ingame_3" };
        AudioManager.Instance.StartPlaylist();
        AudioManager.Instance.PlayUI("Woosh");
    }

    // Update is called once per frame
    void Update()
    {   
        timer += Time.deltaTime;
        if (timer>startdelay)
            isRunning=true;
        if(isRunning){
        theCastles = FindObjectsOfType<Castle>();
        //enemySpawner = FindObjectOfType<SimpleEnemySpawner>();
        waveSpawners = FindObjectsOfType<EnemyWaveSpawner>();


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

            if (pathcounter>10)
            {
                levelActive = false;
                levelVictory = true;


                //UIController.instance.towerButtons.SetActive(false);
            }

            if (!levelActive)
            {
                Debug.Log(levelVictory);
                UIController.instance.levelFailScreen.SetActive(!levelVictory);
                UIController.instance.levelCompleteScreen.SetActive(levelVictory);
                ForschungSystem.instance.ResetList();

                UIController.instance.CloseTowerUpgradePanel();
                Time.timeScale = 0f;
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
}
