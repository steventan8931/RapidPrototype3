using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class SortingLayerSetter : MonoBehaviour
{
    public Renderer m_Renderer;
    public bool m_IsPlayer = false;
    public WorldSwitch m_Switch;
    public Material m_GoodMat;
    public Material m_BadMat;

    public Material m_GoodMatEnemy;
    public Material m_BadMatEnemy;
    public Material m_GoodMatGoodEnemy;
    public Material m_BadMatGoodEnemy;

    public float m_Timer = 0.0f;
    bool m_Changed = false;
    bool m_CacheChange = false;

    private void Start()
    {
        m_Switch = FindObjectOfType<WorldSwitch>();
    }
    private void Update()
    {
        if (m_CacheChange != m_Changed)
        {
            m_Timer += Time.deltaTime;

        }
        if (m_Timer > 0.3f)
        {
            SwitchMat();
            m_CacheChange = m_Changed;
            m_Timer = 0;
        }

        if (m_IsPlayer)
        {
            m_Renderer.sortingLayerName = "Player";
            if (m_Switch.m_Changed)
            {
                m_Changed = !m_Changed;
            }

        }
        else
        {
            m_Renderer.sortingLayerName = "Enemy";
        }


    }

    public void SwitchMat()
    {
        if (m_Switch.m_InGoodWorld)
        {
            m_Renderer.material = m_GoodMat;
        }
        else
        {
            m_Renderer.material = m_BadMat;
        }
    }
}
