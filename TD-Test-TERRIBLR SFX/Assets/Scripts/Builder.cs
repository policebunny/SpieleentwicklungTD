using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public Vector3 StartPosition;
    public Vector3 newPosition;
    public GameObject BobtheBuilder;
    public float MovementSpeed;
    public bool IsBuilding;
    public bool IsMoving;
    public bool DoneBuilding;
    public int BuildTime = 1;

    public Transform indicatorTower;
    public List<Tower> BuildingList = new List<Tower>();
    public Tower toBuild;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    public enum Doing
    {
        IsMoving,
        DoneBuilding,
        IsBuilding
    }

    // Update is called once per frame
    void Update()
    {
        if(IsMoving)
        {
            
            Debug.Log("Move it");
            transform.position = Vector3.MoveTowards(transform.position, newPosition, MovementSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, newPosition) < .8f)
            {
                IsMoving = false;
                IsBuilding = true;
            }
        }
        if (IsBuilding)
        {
            if (BuildTime < 50)
            {
                toBuild.gameObject.SetActive(false);
                BuildTime++;
            } else
            {
                IsBuilding = false;
                BuildTime = 0;
                DoneBuilding = true;
                toBuild.gameObject.SetActive(true);
                // enable Tower, get input from TowerManager
            }
            
        }
        if (DoneBuilding)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPosition, MovementSpeed * Time.deltaTime);
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

    /*
     * Instantiate(activeTower, indicator.position, activeTower.transform.rotation);

                        indicator.gameObject.SetActive(false);

                        UIController.instance.notEnoughMoneyWarning.SetActive(false);

                        AudioManager.instance.PlaySFX(8);
     */

}
