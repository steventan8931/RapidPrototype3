using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    public bool m_InAttackRange = false;
    public bool m_ChargeAttack = false;
    public Vector2 m_Force;

    public float m_Timer = 0.0f;
    public float m_Cooldown = 3.0f;

    public bool m_Hit = false;
    public bool m_CanAttack = false;

    public Transform m_EnemyPos;

    public Transform m_ScratchFXPos;

    public GameObject m_ScratchFXPrefab;
    private void OnTriggerStay2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            m_InAttackRange = true;
            m_CanAttack = true;
            if (m_ChargeAttack)
            {
                _collision.GetComponent<playercontroller>().enabled = false;
                Vector3 dir = (_collision.transform.position - m_EnemyPos.position);
                
                Debug.Log(dir);
                if (dir.x > 0)
                {
                    _collision.attachedRigidbody.AddForce(new Vector2(m_Force.x, m_Force.y) * Time.deltaTime, ForceMode2D.Impulse);
                    Instantiate(m_ScratchFXPrefab, m_ScratchFXPos);
                    m_ChargeAttack = false;
                    m_Timer = 0;
                }
                else if (dir.x < 0)
                {
                    _collision.attachedRigidbody.AddForce(new Vector2(-m_Force.x, m_Force.y) * Time.deltaTime, ForceMode2D.Impulse);
                    Instantiate(m_ScratchFXPrefab, m_ScratchFXPos);
                    m_ChargeAttack = false;
                    m_Timer = 0;
                }
                m_Hit = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D _collision)
    {
        m_CanAttack = false;
        _collision.GetComponent<playercontroller>().enabled = true;
    }

    private void Update()
    {
        if (m_InAttackRange)
        {
            m_Timer += Time.deltaTime;
        }

        if (!m_CanAttack)
        {
            m_Hit = false;
            m_Timer = 0;
        }
        if (m_Timer > m_Cooldown)
        {
            m_ChargeAttack = true;

        }

    }
}
