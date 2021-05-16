using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    [SerializeField] private float harvestTime = 0.4f;

    private PlayerMovement playerMovement;
    private PlayerInventory playerInventory;

    private AudioSource audioSource;
    private Collider2D bushCollider;

    private BushFruits hitBush;

    private bool canHarvest;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInventory = GetComponent<PlayerInventory>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TryHarvestFruits();
        }
    }

    void TryHarvestFruits()
    {
        if(!canHarvest)
        {
            return;
        }

        if(bushCollider != null)
        {
            hitBush = bushCollider.GetComponent<BushFruits>();

            if(hitBush.HasFruits())
            {
                audioSource.Play();
                playerMovement.StopMovement(harvestTime);
                playerInventory.AddFruits(hitBush.HarvestFruits());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bush"))
        {
            canHarvest = true;
            bushCollider = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bush"))
        {
            canHarvest = false;
            bushCollider = null;
        }
    }
}
