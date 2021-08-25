using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Door m_Door;

    private void OnTriggerStay2D(Collider2D _collision)
    {
        if (_collision.GetComponent<Test>().m_KeyCollected)
        {
            m_Door.m_IsOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D _collision)
    {
        if (_collision.GetComponent<Test>().m_KeyCollected)
        {
            m_Door.m_IsOpen = false;
        }
    }
}
