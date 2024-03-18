using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public Tower towerToPlace;

    public void SelectTower()
    {
        Debug.Log("Pressed");
        TowerManager.instance.StartTowerPlacement(towerToPlace);
    }
}
