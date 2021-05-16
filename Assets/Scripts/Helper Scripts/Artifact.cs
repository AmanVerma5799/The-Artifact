using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{

    public int health;
    public int maxHealth = 150;
    public int bleed = 2;

    private AudioSource audioSource;
    private PlayerInventory inventory;
    private float bleedTimer;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        health = maxHealth;

        bleedTimer = Time.time + 1f;
    }

    void Update()
    {
        if(Time.time > bleedTimer)
        {
            health -= bleed;
            bleedTimer = Time.time + 1f;
        }

        CheckHealth();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        CheckHealth();
    }

    void CheckHealth()
    {
        if(health < 0)
        {
            health = 0;

            GameOverUI.instance.GameOver("You Lose!");

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(inventory.storedFruits != 0)
            {
                audioSource.Play();
                health += inventory.TakeFruit();
            }

            if(health > maxHealth)
            {
                health = maxHealth; 
            }
        }
    }
}
