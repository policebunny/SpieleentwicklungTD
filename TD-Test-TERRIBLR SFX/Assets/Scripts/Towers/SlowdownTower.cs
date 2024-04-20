using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownTower : MonoBehaviour
{
    private Tower theTower;

    public Transform effectRing;

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(EnemyController enemy in theTower.enemiesInRange)
        {
            enemy.speedMod = theTower.fireRate;
        }

        effectRing.localScale = new Vector3(theTower.range, 1f, theTower.range);
    }
}
