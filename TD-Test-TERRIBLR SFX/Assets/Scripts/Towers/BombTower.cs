using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : MonoBehaviour
{
    private Tower theTower;

    //public float timeBetweenBombs;
    private float bombCounter;

    public Bomb theBomb;

    public Transform spawnPoint;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();

        bombCounter = theTower.fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        bombCounter -= Time.deltaTime;

        if(theTower.enemiesInRange.Count > 0)
        {
            if(bombCounter <= 0)
            {
                float minDistance = theTower.range + 1f;
                foreach (EnemyController enemy in theTower.enemiesInRange)
                {
                    if (enemy != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            target = enemy.transform;
                        }
                    }
                }

                bombCounter = theTower.fireRate;

                Bomb newBomb = Instantiate(theBomb, spawnPoint.position, Quaternion.identity);
                newBomb.targetPoint = target.position;
            }
        }
    }
}
