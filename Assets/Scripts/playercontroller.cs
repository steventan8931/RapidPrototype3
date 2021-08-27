﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // player: move, jump, collect drugs
    // advanced: crouch, sprint
    public int hitpoints = 3;
    public float drugBar = 100f;
    public float currentDrug = 0;
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

    //bool for check vent location
    public bool nearVent = false;
    public Transform nearestVentLoc;
    public GameObject VentUI;


    public bool ishidden = false;
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
            //setting movement in drug state
        {
            if (currentDrug >= 0)
            {
                currentDrug -= 0.1f;
                if(currentDrug < 0)
                {
                    currentDrug = 0;
                }
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
                currentDrug -= 3;
                if(currentDrug <=0)
                {
                    currentDrug = 0;
                }
            }
            isgrounded = false;
        }
        checkVent();
        
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
    public void getNextVentLoc(Transform ventLoc)
    {
        nearestVentLoc = ventLoc;
    }
    public void checkVent()
    {
        if(nearVent == true)
        {
            
            //pop up the ui

            //TRANSFORM to location
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.transform.position = nearestVentLoc.position;
                nearVent = false;
            }

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
        if(nearVent == true)
        {
            VentUI.SetActive(true);
        }else
        {
            VentUI.SetActive(false);
        }
        
        
    }

    private void FixedUpdate()
    {
        // Move velocity
        Move();
        checkDrugStat();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       /* if(collision.gameObject.layer == 8)//collided with floor
        {
            isgrounded = true;
        }*/

        if(collision.gameObject.layer == 10)
        {
            print("found a drug!");
            collision.gameObject.GetComponent<DrugTrigger>().eatDrug();
            currentDrug += 80;
            if(currentDrug > 100)
            {
                currentDrug = 100;
            }

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)//collided with floor
        {
            isgrounded = true;
        } 

       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       

        if (collision.gameObject.layer == 8)//collided with floor
        {
            isgrounded = false;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Vent")
        {
            nearVent = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Vent")
        {
            nearVent = false;
        }
    }
}
