using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    public bool m_InAttackRange = false;
    public Vector2 m_Force;
    private void OnTriggerStay2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            m_InAttackRange = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            _collision.attachedRigidbody.AddForce(m_Force);
        }
    }

    private void OnTriggerExit2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            m_InAttackRange = false;
        }
    }
}
