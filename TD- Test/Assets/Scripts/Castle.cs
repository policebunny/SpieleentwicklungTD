using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{

    public float totalHealth = 100f;

    [HideInInspector]
    public float currentHealth;

    public Slider healthBar;

    public Transform[] attackPoints;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
        healthBar.maxValue = totalHealth;
        healthBar.value = currentHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damageToTake)
    {
        currentHealth -=  damageToTake;

        if(currentHealth<= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }

        healthBar.value = currentHealth;
    }
}
