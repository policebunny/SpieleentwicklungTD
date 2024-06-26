using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUpgradePanel : MonoBehaviour
{
    public GameObject rangeButton, firerateButton;
    public TMP_Text rangeText, firerateText;
    public Builder bob;

    public void SetupPanel()
    {
        if(TowerManager.instance.selectedTower.upgrader.hasRangeUpgrade)
        {
            TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
            rangeText.text = "Upgrade\nRange\n(" + upgrader.rangeUpgrades[upgrader.currentRangeUpgrade].cost + "G)";

            rangeButton.SetActive(true);
        } else
        {
            rangeButton.SetActive(false);
        }

        if(TowerManager.instance.selectedTower.upgrader.hasFirerateUpgrade)
        {
            TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
            firerateText.text = upgrader.fireRateText + "(" + upgrader.firerateUpgrades[upgrader.currentFirerateUpgrade].cost + "G)";

            firerateButton.SetActive(true);
        } else
        {
            firerateButton.SetActive(false);
        }
    }

    public void RemoveTower()
    {
        MoneyManager.instance.SpendMoney(-50);

        Destroy(TowerManager.instance.selectedTower.gameObject);

        UIController.instance.CloseTowerUpgradePanel();

    }

    public void UpgradeRange()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if (upgrader.hasRangeUpgrade)
        {
            if(MoneyManager.instance.SpendMoney(upgrader.rangeUpgrades[upgrader.currentRangeUpgrade].cost))
            {
                // upgrader.UpgradeRange();

                bob.AddTowerToList(TowerManager.instance.selectedTower, TowerManager.instance.selectedTower.transform, 1);

                // bob.AddTowerToList(TowerManager.instance.selectedTower, TowerManager.instance.selectedTower.transform, 1);
                // Add Job Upgrade Range 1 to List
                // bob.upgraderList.Add(upgrader);

                SetupPanel();

                UIController.instance.notEnoughMoneyWarning.SetActive(false);

            } else
            {
                UIController.instance.notEnoughMoneyWarning.SetActive(true);
            }

        }
    }

    public void UpgradeFireRate()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if(upgrader.hasFirerateUpgrade)
        {
            if (MoneyManager.instance.SpendMoney(upgrader.firerateUpgrades[upgrader.currentFirerateUpgrade].cost))
            {
                // upgrader.UpgradeFireRate();

                bob.AddTowerToList(TowerManager.instance.selectedTower, TowerManager.instance.selectedTower.transform, 2);

                // bob.AddTowerToList(TowerManager.instance.selectedTower, TowerManager.instance.selectedTower.transform, 2);
                // Add Job Upgrade Firerate 2 to List
                // bob.upgraderList.Add(upgrader);

                SetupPanel();

                UIController.instance.notEnoughMoneyWarning.SetActive(false);

            }
            else
            {
                UIController.instance.notEnoughMoneyWarning.SetActive(true);
            }
        }
    }
}
