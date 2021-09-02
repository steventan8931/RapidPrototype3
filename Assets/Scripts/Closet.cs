using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    public bool m_ClosetOpen = true;
    public bool m_StartedClosed = false;
    public GameObject m_Open;
    public GameObject m_Closed;
    public bool m_Colliding = false;

    public SoundManageScr soundManager;

    void Start()
    {
        soundManager = GameObject.FindObjectOfType<SoundManageScr>();
    }

    private void OnTriggerStay2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            if (!_collision.GetComponent<playercontroller>().m_DeadAnimPlayed)
            {
                _collision.GetComponent<playercontroller>().VentUI.SetActive(true);
                m_Colliding = true;
                if (m_ClosetOpen)
                {
                    _collision.GetComponent<playercontroller>().ishidden = false;
                    _collision.GetComponent<playercontroller>().enabled = true;
                    m_StartedClosed = false;
                }
                else
                {
                    if (!m_StartedClosed)
                    {
                        _collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        _collision.GetComponent<playercontroller>().ishidden = true;
                        _collision.GetComponent<playercontroller>().m_Animation.SetBool("IsWalking", false);
                        _collision.GetComponent<playercontroller>().enabled = false;
                    }

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            m_Colliding = false;
            _collision.GetComponent<playercontroller>().VentUI.SetActive(false);
            _collision.GetComponent<playercontroller>().ishidden = false;
            _collision.GetComponent<playercontroller>().enabled = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_Colliding)
        {
            soundManager.PlaySound("closet");
            m_ClosetOpen = !m_ClosetOpen;
        }

        if (m_ClosetOpen)
        {
            m_Open.SetActive(true);
            m_Closed.SetActive(false);
        }
        else
        {
            m_Open.SetActive(false);
            m_Closed.SetActive(true);
        }
    }


}
