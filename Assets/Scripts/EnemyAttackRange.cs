using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    public bool m_InAttackRange = false;

    private void OnTriggerStay2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            m_InAttackRange = true;
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
