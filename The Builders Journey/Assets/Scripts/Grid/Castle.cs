using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public float totalHealth = 100f;
    // [HideInInspector]
    public float currentHealth;

    public Slider healthSlider;

    public Transform[] attackPoints;
    private float timemax = 5f;

    private float timer = 0f;

    private List<string> SFX = new List<string> { "Castle_damage_1", "Castle_damage_2", "Castle_damage_3", "Castle_damage_4", "Castle_damage_5", "Castle_damage_6", "Castle_damage_7", "Castle_damage_8" };


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
        timer += Time.deltaTime;
        if (timer > timemax)
        {
            if (currentHealth < totalHealth)
            {
                timer = 0;
                currentHealth += 1f;
                healthSlider.value = currentHealth;
            }
        }

    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);

        }
        else
        {
            AudioManager.Instance.PlaySFX(getRandomSound());
        }

        healthSlider.value = currentHealth;
    }

    private string getRandomSound()
    {
        int index = Random.Range(0, SFX.Count);
        return SFX[index];
    }
}
