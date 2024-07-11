using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;

public class TowerUpgradePanelNew : MonoBehaviour
{
    public GameObject rangeButton, firerateButton;
    public List<GameObject> TowerIcons = new List<GameObject>();
    public TMP_Text rangeText, rangeLevel, rangeCost;
    public TMP_Text firerateText, firerateLevel, firerateCost;
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
            firerateText.text = upgrader.fireRateText;
            firerateCost.text = upgrader.firerateUpgrades[upgrader.currentFirerateUpgrade].cost + " Bones";
            firerateLevel.text = upgrader.currentFirerateUpgrade + "";

            firerateButton.SetActive(true);
        }
        else
        {
            firerateButton.SetActive(false);
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
