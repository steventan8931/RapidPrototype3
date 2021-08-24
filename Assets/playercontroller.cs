using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // player: move, jump, collect drugs
    // advanced: crouch, sprint
    public int drugBar;
    public float movespeed, sprintspeed;
    public float jumpForce;
    private float moveDir;
    private Rigidbody2D rb;
    private bool faceRight = true; //for 2d sprite
    private bool isJumping = false;// touches ground: false, in air: true
    public bool isgrounded;

    //public Transform cellingcheck;
    //public Transform groundcheck;
    public LayerMask groundObj;
    public float checkradius = 0.1f;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void flipPlayer()
    {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void doFlip()
    {
        if (moveDir > 0 && !faceRight)
        {
            flipPlayer();
        }
        else if (moveDir < 0 && faceRight)
        {
            flipPlayer();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDir * movespeed, rb.velocity.y);
        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        isJumping = false;
    }

    private void InputFunc()
    {
        moveDir = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isgrounded)
        {
            isJumping = true;
            print("Jumped!");
            isgrounded = false;
        }
        
    }
    // Update is called once per frame
    private void Update()
    {
        //Input Func
        InputFunc();
        // Move Animation
        // flip when moving
        doFlip();
        
        
    }

    private void FixedUpdate()
    {
        
        // Move velocity
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)//collided with floor
        {
            isgrounded = true;
        }
    }
}
