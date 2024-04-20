using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public float totalHealth = 100f;
    [HideInInspector]
    public float currentHealth;

    public Slider healthSlider;

    public Transform[] attackPoints;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;

        healthSlider.maxValue = totalHealth;
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);

            AudioManager.instance.PlaySFX(3);
        } else
        {
            AudioManager.instance.PlaySFX(4);
        }

        healthSlider.value = currentHealth;
    }
}
