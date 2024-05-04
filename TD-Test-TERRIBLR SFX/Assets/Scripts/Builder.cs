using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public Vector3 StartPosition;
    // public Vector3 newPosition;
    public Vector3 rightClickMovement;
    public GameObject BobtheBuilder;
    public float MovementSpeed;

    public bool IsBuilding;
    public bool IsMoving;
    public bool DoneBuilding;

    public float BuildTime = 1;
    public float BuildDone = 5;

    public List<Tower> BuildingList = new List<Tower>();
    public List<Transform> BuildTransformList = new List<Transform>();
    public List<int> WhatToDoList = new List<int>();

    public List<TowerUpgradeController> upgraderList = new List<TowerUpgradeController>();
    /* WhatToDoList Dictionary
     *  0 = default, new Tower
     *  1 = Upgrade Range
     *  2 = Upgrade Firerate
     *  
     */

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        
    }


    // Update is called once per frame
    void Update()
    {
        // 0 f�r left mouse button, 1 f�r right mouse button, 2 f�r middle mouse button
        if (Input.GetMouseButtonDown(1))  
        {
            // reset list of Build and move instead
            if (BuildingList.Count != 0)
            {
                // brich ab und refund money
                foreach (Tower tower in BuildingList)
                {
                    MoneyManager.instance.GiveMoney(tower.cost);
                }
                foreach (Transform indicator in BuildTransformList)
                {
                    indicator.gameObject.SetActive(false);
                    Destroy(indicator.gameObject);
                }
                BuildingList.Clear();
                BuildTransformList.Clear();

            }

            // get new mouse position to move towards
            rightClickMovement = TowerManager.instance.GetGridPosition();

            IsBuilding = false;
            DoneBuilding = false;
            IsMoving = true;
        }

        if (BuildingList.Count != 0)
        {
            // to stuff while list has elements
            if (IsMoving)
            {
                
                //Debug.Log("Move it");
                transform.position = Vector3.MoveTowards(transform.position, BuildTransformList[0].position, MovementSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, BuildTransformList[0].position) < .8f)
                {
                    IsMoving = false;
                    IsBuilding = true;
                }
            }
            if (IsBuilding)
            {
                if (BuildTime < BuildDone)
                {
                    BuildingList[0].gameObject.SetActive(false);
                    // toBuild.gameObject.SetActive(false);
                    BuildTime += Time.deltaTime;
                }
                else
                {
                    IsBuilding = false;
                    BuildTime = 0;
                    DoneBuilding = true;
                    BuildingList[0].gameObject.SetActive(true);
                    if (WhatToDoList[0] == 0)
                    {
                        CompletedTower();
                    } else
                    {
                        UpgradedTower();
                    }


                    // enable Tower, get input from TowerManager
                }

            }
            if (DoneBuilding)
            {
                if(BuildingList.Count != 0)
                {
                    IsMoving = true;
                    DoneBuilding = false;
                } else
                {
                    transform.position = Vector3.MoveTowards(transform.position, StartPosition, MovementSpeed * Time.deltaTime);
                }
                
            }

        } else
        {
            if (IsMoving)
            {

                Debug.Log("Move it");
                transform.position = Vector3.MoveTowards(transform.position, rightClickMovement, MovementSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, rightClickMovement) < .1f)
                {
                    IsMoving = false;
                }
            }

        }
        
    }

    public bool StillMoving()
    {
        return IsMoving;
    }

    public bool Done_Building()
    {
        return DoneBuilding;
    }

    public void TowerInstantiate(Tower TowerAdded, Transform indicatorAdded)
    {
        Instantiate(TowerAdded, indicatorAdded.position, BuildingList[0].transform.rotation);
        indicatorAdded.gameObject.SetActive(false);
        UIController.instance.notEnoughMoneyWarning.SetActive(false);
        AudioManager.instance.PlaySFX(8);
        Destroy(indicatorAdded.gameObject);
        /*
     * Instantiate(activeTower, indicator.position, activeTower.transform.rotation);

                        indicator.gameObject.SetActive(false);

                        UIController.instance.notEnoughMoneyWarning.SetActive(false);

                        AudioManager.instance.PlaySFX(8);
     */
        // TowerAdded.gameObject.SetActive(false);


    }

    public void CompletedTower()
    {
        TowerInstantiate(BuildingList[0], BuildTransformList[0]);
        BuildingList.RemoveAt(0);
        BuildTransformList.RemoveAt(0);
        WhatToDoList.RemoveAt(0);
    }

    public void AddTowerToList(Tower newOrderTower, Transform newOrderTransform, int whichJob)
    {
        if (BuildingList.Count == 0)
        {
            IsMoving = true;
        }
        newOrderTower.gameObject.SetActive(true);
        BuildingList.Add(newOrderTower);
        BuildTransformList.Add(newOrderTransform);
        WhatToDoList.Add(whichJob);
 
    }

    public void UpgradedTower()
    {
        // DO UPGRADE INITIATE
        switch(WhatToDoList[0])
        {
            case 0:  // default new tower
                // should never reach here
                break;
            case 1:
                // Upgrade Range
                break;
            case 2:
                // Upgrade Firerate
                break;
            default:
                break;
        }

        BuildingList.RemoveAt(0);
        BuildTransformList.RemoveAt(0);
        WhatToDoList.RemoveAt(0);
        upgraderList.RemoveAt(0);
        
    }

}
