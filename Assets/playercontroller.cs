using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // player: move, jump, collect drugs
    // advanced: crouch, sprint
    public int drugBar = 100;
    public int currentDrug = 0;
    public float movespeed, sprintspeed;
    public float jumpForce;
    private float moveDir;
    private Rigidbody2D rb;
    private bool faceRight = true; //for 2d sprite
    private bool isJumping = false;// touches ground: false, in air: true
    public bool isgrounded;

    public bool isdead = false;

    //public Transform cellingcheck;
    //public Transform groundcheck;
    public LayerMask groundObj;
    public float checkradius = 0.1f;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeed = 5;
        
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
        if(moveDir * movespeed != 0)
        {
            if (currentDrug >= 50)
            {
                currentDrug -= 1;
            }
        }
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
            if(currentDrug >= 50)
            {
                currentDrug -= 5;
            }
            isgrounded = false;
        }
        
    }

    private void checkDrugStat()
    {
        //if drug bar is above 50, increase the movement speed
        //Jump and move will consume drug bar when currentDrug >0
        if(currentDrug >= 50)
        {
            movespeed = 8;
        }
        //if drug bar is below 30, do UI effect

        //if drug bar equals to 0, do UI effect
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
        checkDrugStat();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)//collided with floor
        {
            isgrounded = true;
        }

        if(collision.gameObject.layer == 10)
        {
            print("found a drug!");
            collision.gameObject.GetComponent<DrugTrigger>().eatDrug();
            currentDrug += 80;

        }
    }
}
