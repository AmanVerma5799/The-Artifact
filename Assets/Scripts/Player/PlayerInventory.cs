using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int maxFruits = 50;
    public int storedFruits;

    [SerializeField] private Text fruitsStoredText;


    private void Start()
    {
        SetInventoryInfo(0);    
    }

    public void AddFruits(int amount)
    {
        storedFruits += amount;

        if (storedFruits > maxFruits)
        {
            storedFruits = maxFruits;
        }

        SetInventoryInfo(storedFruits);
    }

    public int TakeFruit()
    {
        int takenFruits = storedFruits;
        storedFruits = 0;

        SetInventoryInfo(storedFruits);

        return takenFruits;
    }

    void SetInventoryInfo(int amount)
    {
        fruitsStoredText.text = "Inventory : " + amount + "/" + maxFruits;
    }
}
