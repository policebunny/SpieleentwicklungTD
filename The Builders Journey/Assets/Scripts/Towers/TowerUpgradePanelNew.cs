using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;

public class TowerUpgradePanelNew : MonoBehaviour
{
    public GameObject rangeButton, firerateButton, slowButton;
    public List<GameObject> TowerIcons = new List<GameObject>();
    public TMP_Text rangeText, rangeLevel, rangeCost;
    public TMP_Text firerateText, firerateLevel, firerateCost;
    public TMP_Text slowText, slowLevel, slowCost;
    public bool mouseOver = false;

    public void SetupPanel()
    {
        if (TowerManager.instance.selectedTower.upgrader.hasRangeUpgrade)
        {
            TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
            rangeText.text = "Range";
            rangeCost.text = upgrader.rangeUpgrades[upgrader.currentRangeUpgrade].cost + " Bones";
            rangeLevel.text = upgrader.currentRangeUpgrade + "";

            rangeButton.SetActive(true);
        }
        else
        {
            rangeButton.SetActive(false);
        }

        if (TowerManager.instance.selectedTower.upgrader.hasFirerateUpgrade)
        {
            TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
            if(TowerManager.instance.selectedTower.isTower == 2)
            {
                firerateButton.SetActive(false);
                slowButton.SetActive(true);
                slowText.text = upgrader.fireRateText;
                slowCost.text = upgrader.firerateUpgrades[upgrader.currentFirerateUpgrade].cost + " Bones";
                slowLevel.text = upgrader.currentFirerateUpgrade + "";
            } else
            {
                slowButton.SetActive(false);
                firerateButton.SetActive(true);
                firerateText.text = upgrader.fireRateText;
                firerateCost.text = upgrader.firerateUpgrades[upgrader.currentFirerateUpgrade].cost + " Bones";
                firerateLevel.text = upgrader.currentFirerateUpgrade + "";
            }
            
        }
        else
        {
            firerateButton.SetActive(false);
        }
        foreach (GameObject icon in TowerIcons)
        {
            icon.SetActive(false);
        }
        switch(TowerManager.instance.selectedTower.isTower)
        {
            case 0:
                TowerIcons[0].SetActive(true);
                break;
            case 1:
                TowerIcons[1].SetActive(true);
                break;
            case 2:
                TowerIcons[2].SetActive(true);
                break;
            case 3:
                TowerIcons[3].SetActive(true);
                break;
            default:
                TowerIcons[0].SetActive(true);
                break;
        }

    }

    public void RemoveTower()
    {
        MoneyManager.instance.SpendMoney(-50);

        Destroy(TowerManager.instance.selectedTower.gameObject);

        UIController.instance.CloseTowerUpgradePanel();

        AudioManager.Instance.PlaySFX("Tower_placed_1");
    }

    public void UpgradeRange()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if (upgrader.hasRangeUpgrade)
        {
            if (MoneyManager.instance.SpendMoney(upgrader.rangeUpgrades[upgrader.currentRangeUpgrade].cost))
            {
                upgrader.UpgradeRange();

                SetupPanel();

                UIController.instance.notEnoughMoneyWarning.SetActive(false);

                AudioManager.Instance.PlaySFX("Tower_placed_1");
            }
            else
            {
                UIController.instance.notEnoughMoneyWarning.SetActive(true);
            }

        }
    }

    public void UpgradeFireRate()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if (upgrader.hasFirerateUpgrade)
        {
            if (MoneyManager.instance.SpendMoney(upgrader.firerateUpgrades[upgrader.currentFirerateUpgrade].cost))
            {
                upgrader.UpgradeFireRate();

                SetupPanel();

                UIController.instance.notEnoughMoneyWarning.SetActive(false);

                AudioManager.Instance.PlaySFX("Tower_placed_1");
            }
            else
            {
                UIController.instance.notEnoughMoneyWarning.SetActive(true);
            }
        }
    }

    public void OnMouseOver()
    {
        mouseOver = true;
    }

    public void OnMouseExit()
    {
        mouseOver = false;
    }

}
