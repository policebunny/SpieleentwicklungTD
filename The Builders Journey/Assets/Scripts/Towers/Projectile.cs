using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed;

    public GameObject impactEffect;

    public float damageAmount;

    private bool hasDamaged;

    // Start is called before the first frame update
    void Start()
    {
        theRB.velocity = transform.forward * moveSpeed;

        AudioManager.Instance.PlaySFX("Tower_placed_1");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && !hasDamaged)
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(damageAmount);
            hasDamaged = true;
        }

        Instantiate(impactEffect, transform.position, Quaternion.identity);

        AudioManager.Instance.PlaySFX("Enemy_damage_1");

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
