using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentV2 : MonoBehaviour
{
    public bool m_PlayerNear = false;
    public Transform m_ExitLocation;
    public GameObject m_Player;

    public SoundManageScr soundManager;

    void Start()
    {
        soundManager = GameObject.FindObjectOfType<SoundManageScr>();
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            m_PlayerNear = true;
            _collision.GetComponent<playercontroller>().VentUI.SetActive(true);
            m_Player.GetComponent<playercontroller>().nearVent = true;
        }
    }

    private void OnTriggerExit2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            m_PlayerNear = false;
            _collision.GetComponent<playercontroller>().VentUI.SetActive(false);
            m_Player.GetComponent<playercontroller>().nearVent = false;
        }
    }

    private void Update()
    {
        if(m_PlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                soundManager.PlaySound("vent");
                m_Player.transform.position = m_ExitLocation.position;
            }
        }
    }
}
