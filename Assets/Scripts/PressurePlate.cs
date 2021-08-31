using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Door m_Door;

    public SoundManageScr soundManager;

    void Start()
    {
        soundManager = GameObject.FindObjectOfType<SoundManageScr>();
    }

    private void OnTriggerStay2D(Collider2D _collision)
    {
        if (_collision.GetComponent<playercontroller>().hasKey)
        {
            m_Door.m_IsOpen = true;
            soundManager.PlaySound("door");
            _collision.GetComponent<playercontroller>().hasKey = false;
        }
    }

    private void OnTriggerExit2D(Collider2D _collision)
    {
        //if (_collision.GetComponent<playercontroller>().hasKey)
        //{
        //    if (!m_Door.m_StaysOpen)
        //    {
        //        m_Door.m_IsOpen = false;
        //    }

        //}
    }
}
