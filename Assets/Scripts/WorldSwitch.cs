using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitch : MonoBehaviour
{
    public bool m_InGoodWorld = false;

    public GameObject m_GoodWorld;
    public GameObject m_BadWorld;

    public GameObject m_GoodWorldBg;
    public GameObject m_BadWorldBg;

    public Animator m_Animation;

    public float m_Timer;
    public float m_DelayTimer = 1.1f;
    public bool m_Changed = false;
    public bool m_EnemyChange = false;

    //public GameObject m_LightBad;
    public GameObject m_LightGood;

    public void ActivateWorldSwitch()
    {
        m_InGoodWorld = !m_InGoodWorld;
        m_Animation.ResetTrigger("Fade To");
        m_Animation.SetTrigger("Fade To");
        m_Changed = true;
    }

    private void Start()
    {
        if (m_InGoodWorld)
        {
            m_GoodWorld.SetActive(true);
            m_BadWorld.SetActive(false);

            m_GoodWorldBg.SetActive(true);
            m_BadWorldBg.SetActive(false);

            //m_LightBad.SetActive(false);
            m_LightGood.SetActive(true);
        }
        else
        {
            m_GoodWorld.SetActive(false);
            m_BadWorld.SetActive(true);

            m_GoodWorldBg.SetActive(false);
            m_BadWorldBg.SetActive(true);

            //m_LightBad.SetActive(true);
            m_LightGood.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ActivateWorldSwitch();
        }
        if (m_Changed)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer > m_DelayTimer)
            {
                if (m_InGoodWorld)
                {
                    m_GoodWorld.SetActive(true);
                    m_BadWorld.SetActive(false);

                    m_GoodWorldBg.SetActive(true);
                    m_BadWorldBg.SetActive(false);

                    //m_LightBad.SetActive(false);
                    m_LightGood.SetActive(true);
                }
                else
                {
                    m_GoodWorld.SetActive(false);
                    m_BadWorld.SetActive(true);

                    m_GoodWorldBg.SetActive(false);
                    m_BadWorldBg.SetActive(true);

                    //m_LightBad.SetActive(true);
                    m_LightGood.SetActive(false);
                }
                m_Changed = false;
                m_Timer = 0;
            }
            
        }

    }
}
