using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    public float totalHealth;

    public Slider healthBar;

    public int moneyOnDeath = 50;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = totalHealth;
        healthBar.value = totalHealth;

        LevelManager.instance.activeEnemies.Add(this);

        AudioManager.instance.PlaySFX(7);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.rotation = Camera.main.transform.rotation;
    }

    public void TakeDamage(float damageAmount)
    {
        totalHealth -= damageAmount;
        if(totalHealth <= 0)
        {
            totalHealth = 0;

            Destroy(gameObject);

            MoneyManager.instance.GiveMoney(moneyOnDeath);

            LevelManager.instance.activeEnemies.Remove(this);

            AudioManager.instance.PlaySFX(5);
        }

        healthBar.value = totalHealth;
        healthBar.gameObject.SetActive(true);

    }
}
