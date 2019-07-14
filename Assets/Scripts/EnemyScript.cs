using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    // delegate avoids null check so no exception will be thrown
    public event Action<float> UpdateHealthBar = delegate { };

    private void DeductPoints(int damageAmount)
    {
        // updates current health
        currentHealth -= damageAmount;

        // get's the current health as a percentage
        float currentHealthPct = (float)currentHealth / (float)maxHealth;

        UpdateHealthBar(currentHealthPct);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
