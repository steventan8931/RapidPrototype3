﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum EnemyState
    {
        Patrolling,
        Seeking,
        Attacking,
    }

    EnemyState m_CurrentState;

    [Header("Movement")]
    public float m_MoveSpeed = 5f;
    public Transform m_Model;


    [Header("Patrolling")]
    public bool m_MovingRight = false;
    public Vector2 m_RoamingExtents;

    Vector2 m_LeftPosition;
    Vector2 m_RightPosition;

    [Header("Seeking")]
    public EnemyDetect m_DetectField;

    [Header("Attacking")]
    public EnemyAttackRange m_AttackField;
    public GameObject m_Weapon;

    private void Start()
    {
        m_CurrentState = EnemyState.Patrolling;
        m_LeftPosition = new Vector2(m_RoamingExtents.x, transform.position.y);
        m_RightPosition = new Vector2(m_RoamingExtents.y, transform.position.y);
    }

    void Patrol()
    {
        if (transform.position.x <= m_LeftPosition.x)
        {
            m_MovingRight = true;
            m_Model.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.position.x >= m_RightPosition.x)
        {
            m_MovingRight = false;
            m_Model.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (m_MovingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_RightPosition, Time.deltaTime * m_MoveSpeed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, m_LeftPosition, Time.deltaTime * m_MoveSpeed);
        }
    }

    void Seek()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_DetectField.m_PlayerPosition, Time.deltaTime * m_MoveSpeed);
    }
    private void Update()
    {
        if (m_DetectField.m_Detected)
        {
            if (m_AttackField.m_InAttackRange)
            {
                m_CurrentState = EnemyState.Attacking;
                m_Weapon.SetActive(true);
            }
            else
            {
                m_CurrentState = EnemyState.Seeking;
                m_Weapon.SetActive(false);
            }
        }
        else
        {
            m_CurrentState = EnemyState.Patrolling;
            m_Weapon.SetActive(false);
        }

        switch (m_CurrentState)
        {
            case EnemyState.Patrolling:
                {
                    Patrol();
                    break;
                }
            case EnemyState.Seeking:
                {
                    Seek();
                    break;
                }
            case EnemyState.Attacking:
                {
                    break;
                }
        }


    }
}
