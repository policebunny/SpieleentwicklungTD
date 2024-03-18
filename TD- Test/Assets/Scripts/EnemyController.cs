using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;

    private Path thePath;
    private int currentPoint;
    private bool reachedGoal;

    public float attackSpeed, damage;
    private float attackCounter;

    private Castle theCastle;

    private int SelectedAttackPoint;


    // Start is called before the first frame update
    void Start()
    {
        if (thePath == null)
        {
            thePath = FindObjectOfType<Path>();
        }

        if (theCastle == null)
        {
            theCastle = FindObjectOfType<Castle>();
        }

        attackCounter = attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (theCastle.currentHealth > 0)
        {
            if (!reachedGoal)
            {
                transform.LookAt(thePath.points[currentPoint]);

                transform.position = Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < .01f)
                {
                    currentPoint = currentPoint + 1;
                    if (currentPoint >= thePath.points.Length)
                    {
                        reachedGoal = true;
                        SelectedAttackPoint = Random.Range(0, theCastle.attackPoints.Length);
                    }
                }

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, theCastle.attackPoints[SelectedAttackPoint].position, moveSpeed * Time.deltaTime);

                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    attackCounter = attackSpeed;

                    theCastle.takeDamage(damage);
                }
            }
        }
    }

    public void Setup(Castle newCastle, Path newPath)
    {
        theCastle = newCastle;
        thePath = newPath;
    }
}
