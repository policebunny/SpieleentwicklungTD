using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{
    private Tower theTower;

    public GameObject projectile;
    public Transform firePoint;
    public float attackSpeed = 1f;
    private float shotCounter;

    private Transform target;
    public Transform launcherModel;

    public GameObject shotEffect;

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            //launcherModel.LookAt(target);
            launcherModel.rotation = Quaternion.Slerp(launcherModel.rotation,Quaternion.LookRotation(target.position - transform.position), 5f*Time.deltaTime);

            launcherModel.rotation = Quaternion.Euler(0f, launcherModel.rotation.eulerAngles.y, 0f);
        
        }

        shotCounter -= Time.deltaTime;
        if(shotCounter<= 0 && target != null)
        {
            shotCounter = attackSpeed;

            firePoint.LookAt(target);

            Instantiate(projectile, firePoint.position, firePoint.rotation);
            Instantiate(shotEffect, firePoint.position, firePoint.rotation);
        }
        if (theTower.enemiesUpdated)
        {
            if (theTower.enemiesInRange.Count > 0)
            {
                //target the closest enemy
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
            }
            else
            {
                target = null;
            }
        }
    }
}
