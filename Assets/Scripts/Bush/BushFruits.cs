using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushFruits : MonoBehaviour
{
    [SerializeField] private int[] amountPerType;
    [SerializeField] private float[] respawnTime;

    private BushVisual bushVisual;

    private bool hasFruits;
    private float timer;

    void Awake()
    {
        bushVisual = GetComponent<BushVisual>();

        if(Random.Range(0, 2) == 0)
        {
            hasFruits = false;
            timer = Time.time + respawnTime[(int)bushVisual.GetBushVariant()];
        }
        else
        {
            hasFruits = true;
            bushVisual.ShowFruits();
        }
    }

    void Update()
    {
        if(Time.time > timer)
        {
            hasFruits = true;
            bushVisual.ShowFruits();
        }
    }

    public int HarvestFruits()
    {
        if(hasFruits)
        {
            hasFruits = false;
            bushVisual.HideFruits();
            timer = Time.time + respawnTime[(int)bushVisual.GetBushVariant()];
            return amountPerType[(int)bushVisual.GetBushVariant()];
        }
        else
        {
            return 0;
        }
    }

    public bool HasFruits()
    {
        return hasFruits;
    }

    public void EatFruits()
    {
        enabled = false;
        bushVisual.SetToDry();
    }
}
