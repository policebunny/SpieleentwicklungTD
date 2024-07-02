using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform pivot, model;

    public float moveSpeed;

    //public Transform target;
    [HideInInspector]
    public Vector3 targetPoint;

    public GameObject explodeEffect;

    public float damageAmount;
    public LayerMask whatIsEnemy;

    public float explodeRange;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPosition = transform.position;

        //targetPoint = target.position;

        Vector3 centerPosition = (transform.position + targetPoint) * .5f;
        transform.position = centerPosition;

        transform.right = targetPoint - transform.position;

        model.transform.position = startPosition;

        AudioManager.Instance.PlaySFX("Cannon_shot_1");
    }

    // Update is called once per frame
    void Update()
    {
        pivot.localRotation = Quaternion.RotateTowards(pivot.localRotation, Quaternion.Euler(0f, 0f, -179f), moveSpeed * Time.deltaTime);
        model.rotation = Quaternion.identity;

        if(Vector3.Distance(model.position, targetPoint) < .1f)
        {

            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, explodeRange, whatIsEnemy);

            foreach(Collider col in collidersInRange)
            {
                col.GetComponent<EnemyHealthController>().TakeDamage(damageAmount);
            }


            if (explodeEffect != null)
            {
                Instantiate(explodeEffect, model.position, Quaternion.identity);
            }

            AudioManager.Instance.PlaySFX("Enemy_damage_1");

            Destroy(gameObject);
        }
    }
}
