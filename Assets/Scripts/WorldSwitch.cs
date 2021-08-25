using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitch : MonoBehaviour
{
    public bool m_InGoodWorld = false;

    public GameObject m_GoodWorld;
    public GameObject m_BadWorld;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            m_InGoodWorld = !m_InGoodWorld;
        }
        if (m_InGoodWorld)
        {
            m_GoodWorld.SetActive(true);
            m_BadWorld.SetActive(false);
        }
        else
        {
            m_GoodWorld.SetActive(false);
            m_BadWorld.SetActive(true);
        }
    }
}
