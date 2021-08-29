using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentV2 : MonoBehaviour
{
    public bool m_PlayerNear = false;
    public Transform m_ExitLocation;
    public GameObject m_Player;

    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            m_PlayerNear = true;
            m_Player.GetComponent<playercontroller>().nearVent = true;
        }
    }

    private void OnTriggerExit2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            m_PlayerNear = false;
            m_Player.GetComponent<playercontroller>().nearVent = false;
        }
    }

    private void Update()
    {
        if(m_PlayerNear)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                m_Player.transform.position = m_ExitLocation.position;
            }
        }
    }
}
