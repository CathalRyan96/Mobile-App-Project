﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleJump : MonoBehaviour
{

    float dirX;

    [SerializeField]
    float jumpForce = 500f, moveSpeed = 5f;

    Rigidbody2D rb;

    bool doubleJumpAllowed = false;
    bool onTheGround = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the y velocity is zero, onTheGround variable is set to true
        if (rb.velocity.y == 0)
            onTheGround = true;
        else
            onTheGround = false;
        //If the player is on the ground double jump is allowed
        if (onTheGround)
            doubleJumpAllowed = true;

        if (onTheGround && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        else if (doubleJumpAllowed && Input.GetButtonDown("Jump"))
        {
            Jump();
            doubleJumpAllowed = false;
        }

        dirX = Input.GetAxis("Horizontal") * moveSpeed;

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); ;
        rb.AddForce(Vector2.up * jumpForce);
    }

}
