using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // player: move, jump, collect drugs
    // advanced: crouch, sprint
    public int drugBar;
    public float movespeed, sprintspeed;
    private float moveDir;
    private Rigidbody2D rb;
    private bool faceRight = true; //for 2d sprite

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void flipPlayer()
    {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        // Move func
        moveDir = Input.GetAxis("Horizontal");
        // Move Animation
        // flip when moving
        if(moveDir > 0 && !faceRight)
        {
            flipPlayer();
        }
        else if (moveDir < 0 && faceRight)
        {
            flipPlayer();
        }
        // Move velocity
        rb.velocity = new Vector2(moveDir * movespeed, rb.velocity.y);
        
    }
}
