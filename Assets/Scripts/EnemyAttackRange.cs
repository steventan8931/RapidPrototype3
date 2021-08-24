using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    public bool m_InAttackRange = false;

    private void OnTriggerStay(Collider _other)
    {
        if (_other.tag == "Player")
        {
            m_InAttackRange = true;
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Player")
        {
            m_InAttackRange = false;
        }
    }
}
