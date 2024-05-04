using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    //[HideInInspector]
    public float speedMod = 1f;

    public Path thePath;
    public GameObject pathpoint;
    private int currentPoint;
    public bool reachedEnd;

    public float timeBetweenAttacks, damagePerAttack;
    private float attackCounter;

    private Castle theCastle;

    public int selectedAttackPoint;

    public bool isFlying;
    public float flyHeight;

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

        attackCounter = timeBetweenAttacks;

        if(isFlying)
        {
            transform.position += Vector3.up * flyHeight;
            currentPoint = thePath.points.Count - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (LevelManager.instance.levelActive)
        {
            if (reachedEnd == false)
            {
                Debug.Log(thePath.points[currentPoint]);
                transform.LookAt(thePath.points[currentPoint]);

                if (!isFlying)
                {

                    transform.position = Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime * speedMod);

                    if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < .01f)
                    {
                        currentPoint = currentPoint + 1;
                        if (currentPoint >= thePath.points.Count)
                        {
                            reachedEnd = true;

                            selectedAttackPoint = Random.Range(0, theCastle.attackPoints.Length);
                        }
                    }
                } else
                {
                    transform.position = Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position + (Vector3.up * flyHeight), moveSpeed * Time.deltaTime * speedMod);

                    if (Vector3.Distance(transform.position, thePath.points[currentPoint].position + (Vector3.up * flyHeight)) < .01f)
                    {
                        currentPoint = currentPoint + 1;
                        if (currentPoint >= thePath.points.Count)
                        {
                            reachedEnd = true;

                            selectedAttackPoint = Random.Range(0, theCastle.attackPoints.Length);
                        }
                    }
                }
            }
            else
            {
                if (!isFlying)
                {
                    transform.position = Vector3.MoveTowards(transform.position, theCastle.attackPoints[selectedAttackPoint].position, moveSpeed * Time.deltaTime * speedMod);
                } else
                {
                    transform.position = Vector3.MoveTowards(transform.position, theCastle.attackPoints[selectedAttackPoint].position + (Vector3.up * flyHeight), moveSpeed * Time.deltaTime * speedMod);
                }

                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    attackCounter = timeBetweenAttacks;

                    theCastle.TakeDamage(damagePerAttack);
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
