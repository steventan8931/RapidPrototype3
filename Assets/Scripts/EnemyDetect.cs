using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public bool m_Detected = false;

    public Vector2 m_PlayerPosition;

    private void OnTriggerStay(Collider _other)
    {
        if (_other.gameObject.tag == "Player")
        {
            m_Detected = true;
            m_PlayerPosition = _other.transform.position;
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Player")
        {
            m_Detected = false;
        }
    }
}
