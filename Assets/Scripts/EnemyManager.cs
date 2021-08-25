using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public WorldSwitch m_Switch;
    public GameObject[] m_Enemies;

    private void Update()
    {
        if(m_Switch.m_InGoodWorld)
        {
            for(int i = 0; i < m_Enemies.Length; i++)
            {
                m_Enemies[i].GetComponent<Enemy>().m_IsPassive = true;
            }
        }
        else
        {
            for (int i = 0; i < m_Enemies.Length; i++)
            {
                m_Enemies[i].GetComponent<Enemy>().m_IsPassive = false;
            }
        }
    }
}
