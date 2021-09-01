using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public bool m_Detected = false;

    public Vector2 m_PlayerPosition;

    private void OnTriggerStay2D(Collider2D _collision)
    {
        if (_collision.tag == "Player" && _collision.GetComponent<playercontroller>().hitpoints > 0)
        {
            if (!_collision.GetComponent<playercontroller>().ishidden)
            {
                m_Detected = true;
                m_PlayerPosition = _collision.transform.position;
            }
            else
            {
                m_Detected = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            m_Detected = false;
        }
    }
}
