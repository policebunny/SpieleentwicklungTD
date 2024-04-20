using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgradeController : MonoBehaviour
{
    private Tower theTower;

    public UpgradeStage[] rangeUpgrades;
    public int currentRangeUpgrade;
    public bool hasRangeUpgrade = true;

    public UpgradeStage[] firerateUpgrades;
    public int currentFirerateUpgrade;
    public bool hasFirerateUpgrade = true;
    [TextArea]
    public string fireRateText;

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
    }

    public void UpgradeRange()
    {
        theTower.range = rangeUpgrades[currentRangeUpgrade].amount;
        currentRangeUpgrade++;
        if(currentRangeUpgrade >= rangeUpgrades.Length)
        {
            hasRangeUpgrade = false;
        }
    }

    public void UpgradeFireRate()
    {
        theTower.fireRate = firerateUpgrades[currentFirerateUpgrade].amount;
        currentFirerateUpgrade++;
        if(currentFirerateUpgrade >= firerateUpgrades.Length)
        {
            hasFirerateUpgrade = false;
        }
    }
}

[System.Serializable]
public class UpgradeStage
{
    public float amount;
    public int cost;
}
