using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3f;

    private Rigidbody2D playerBody;
    private Vector2 moveVector;
    private SpriteRenderer playerSprite;

    private float harvestTimer;
    private bool isHarvesting;

    private GameObject artifact;

    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Time.time > harvestTimer)
        {
            isHarvesting = false;
        }

        FlipPlayerSprite();
    }

    void FixedUpdate()
    {
        if(isHarvesting)
        {
            playerBody.velocity = Vector2.zero;
        }
        else
        {
            moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if(moveVector.magnitude > 1)
            {
                moveVector = moveVector.normalized;
            }

            playerBody.velocity = new Vector2(moveVector.x * movementSpeed, moveVector.y * movementSpeed);
        }
    }

    void FlipPlayerSprite()
    {
        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            playerSprite.flipX = false;
        }
        else if(Input.GetAxisRaw("Horizontal") == -1)
        {
            playerSprite.flipX = true;
        }
    }

    public void StopMovement(float time)
    {
        isHarvesting = true;
        harvestTimer = Time.time + time;
    }

    public bool IsHarvesting()
    {
        return isHarvesting;
    }
}
