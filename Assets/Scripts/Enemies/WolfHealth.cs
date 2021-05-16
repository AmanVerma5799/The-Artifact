using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private int maxHealth = 100;

    private float scale;
    private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        scale = (float)currentHealth / maxHealth;

        healthBar.transform.localScale = new Vector3(scale, healthBar.transform.localScale.y, 1f);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
