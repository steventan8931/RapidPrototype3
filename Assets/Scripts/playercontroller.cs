using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class playercontroller : MonoBehaviour
{
    // player: move, jump, collect drugs
    // advanced: crouch, sprint
    public int hitpoints = 3;
    public float drugBar = 100f;
    public int holdingDrug = 0;
    public int drugCD = 120;
    public int currentDrugCD = 0;
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
    //public Transform nearestVentLoc;
    public GameObject VentUI;
    public bool hasKey = false;
    public SoundManageScr soundManager;

    public CameraShake m_CameraShake;
    public Animator m_Animation;

    public bool ishidden = false;

    public TextMeshProUGUI drugCounter;

    public GameObject LoseUI;
    public bool isLose = false;
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
            m_Animation.SetBool("IsWalking",true);
            soundManager.PlaySound("walk");
            if (currentDrug >= 0)
            {
                currentDrug -= 0.1f;
                if(currentDrug < 0)
                {
                    currentDrug = 0;
                }
            }
           
        }
        else
        {
            m_Animation.SetBool("IsWalking", false);
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
            m_Animation.ResetTrigger("Jumping");
            m_Animation.SetTrigger("Jumping");
            soundManager.PlaySound("jump");
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
        if(Input.GetKeyDown(KeyCode.B) && currentDrugCD == 0)
        {
            // eat storing drug
            useDrug();
        }
    }

    private void checkDrugStat()
    {
        //if drug bar is above 50, increase the movement speed
        //Jump and move will consume drug bar when currentDrug >0
        if (currentDrug >= 50)
        {
            movespeed = 8;
            m_CameraShake.ResetShake();
        }
        else
        {
            movespeed = 5;
        }

        //if drug bar is below 30, do UI effect
        if (currentDrug <= 30 && currentDrug >= 25)
        {
            if (!m_CameraShake.m_ShakeFinished)
            {
                m_CameraShake.StartShake();
                m_CameraShake.m_ShakeFinished = true;
            }
        }
        if (currentDrug <= 5 && currentDrug > 0)
        {
            if (!m_CameraShake.m_ShakeFinishedLast)
            {
                m_CameraShake.m_WorldSwitch.ActivateWorldSwitch();
                m_CameraShake.StartShake();
                m_CameraShake.m_ShakeFinishedLast = true;
            }
        }
        else if (currentDrug <= 0)
        {
            m_CameraShake.ResetShake();
        }
            //if drug bar equals to 0, do UI effect
        }
    public void getNextVentLoc(Transform ventLoc)
    {
        //nearestVentLoc = ventLoc;
    }
    public void checkVent()
    {
        if(nearVent == true)
        {
            
            //pop up the ui

            //TRANSFORM to location
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    gameObject.transform.position = nearestVentLoc.position;
            //    nearVent = false;
            //}

        }
    }
    // Update is called once per frame
    private void Update()
    {
        if(hitpoints == 0)
        {
            isLose = true;
        }
        if(isLose == false)
        {
            //Input Func
            InputFunc();
            // Move Animation
            // flip when moving
            doFlip();
            //if (nearVent == true)
            //{
            //    VentUI.SetActive(true);
            //}
            //else
            //{
            //    VentUI.SetActive(false);
            //}
            if (currentDrugCD > 0)
            {
                currentDrugCD -= 1;
            }
            drugCounter.SetText(holdingDrug.ToString());
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
            m_Animation.ResetTrigger("Collecting");
            m_Animation.SetTrigger("Collecting");
            print("found a drug!");
            if(holdingDrug < 3)
            {
                holdingDrug += 1;
            }
            //soundManager.PlaySound("")
            collision.gameObject.GetComponent<DrugTrigger>().eatDrug();
            //currentDrug += 80;
            //soundManager.PlaySound("drug");
            //if(currentDrug > 100)
            //{
            //    currentDrug = 100;
            //}

        }
    }
    public void useDrug()
    {
        if(holdingDrug > 0)
        {
            m_CameraShake.m_WorldSwitch.ActivateGoodWorldSwitch();
            holdingDrug -= 1;
            currentDrug += 70;
            if (currentDrug >= 100)
            {
                currentDrug = 100f;
            }
            currentDrugCD = 120;
        }
       

    }

    public void WinFunc()
    {
        SceneManager.LoadScene(2);
    }

    public void LoseFunc()
    {
        LoseUI.SetActive(true);
    }
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
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
