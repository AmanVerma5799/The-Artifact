using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] wolfSprites;
    [SerializeField] private float timeThreshold = 0.15f;

    private SpriteRenderer wolfRenderer;

    private int state = 0;
    private float timer;

    private WolfAI wolfAI;

    void Awake()
    {
        wolfRenderer = GetComponent<SpriteRenderer>();
        wolfAI = GetComponent<WolfAI>();
    }


    void Update()
    {
        if(wolfAI.isMoving)
        {
            if (Time.time > timer)
            {
                wolfRenderer.sprite = wolfSprites[state % wolfSprites.Length];
                state++;
                timer = Time.time + timeThreshold;
            }
        }
        else
        {
            wolfRenderer.sprite = wolfSprites[0];
        }

        wolfRenderer.flipX = wolfAI.left;
    }
}
