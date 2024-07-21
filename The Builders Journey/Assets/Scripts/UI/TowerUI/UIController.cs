using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    public TMP_Text goldText;
    public GameObject notEnoughMoneyWarning;

    public GameObject levelCompleteScreen, levelFailScreen;

    public GameObject towerButtons;

    public string levelSelectScene, mainMenuScene;

    public GameObject pauseScreen;

    public TowerUpgradePanelNew towerUpgradePanel;

    public TMP_Text waveText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }/*
        if(Input.GetMouseButtonUp(0))
        {
            if (towerUpgradePanel.gameObject.activeSelf && !towerUpgradePanel.mouseOver) CloseTowerUpgradePanel();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            if (towerUpgradePanel.gameObject.activeSelf && !towerUpgradePanel.mouseOver) CloseTowerUpgradePanel();
        }
        */
    }

    public void PauseUnpause()
    {
        /*
        if(pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);

            Time.timeScale = 0f;
        } else
        {
            pauseScreen.SetActive(false);

            Time.timeScale = 1f;
        }
        */
    }

    public void LevelSelect()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(levelSelectScene);
    }

    public void MainMenu()
    {
        AudioManager.Instance.StopMusic();

        Time.timeScale = 1f;

        SceneManager.LoadScene(mainMenuScene);

        AudioManager.Instance.musicPlaylist = new string[] { "MenuTheme"};
        AudioManager.Instance.StartPlaylist();
    }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(LevelManager.instance.nextLevel);
    }

    public void OpenTowerUpgradePanel()
    {
        if (LevelManager.instance.levelActive)
        {
            towerUpgradePanel.gameObject.SetActive(true);
            towerUpgradePanel.SetupPanel();
        }
    }

    public void CloseTowerUpgradePanel()
    {
        towerUpgradePanel.gameObject.SetActive(false);

        if (TowerManager.instance.selectedTower != null)
        {
            TowerManager.instance.selectedTower.rangeModel.SetActive(false);
            TowerManager.instance.selectedTower = null;
        }

        TowerManager.instance.selectedTowerEffect.SetActive(false);

        notEnoughMoneyWarning.SetActive(false);
    }
}
