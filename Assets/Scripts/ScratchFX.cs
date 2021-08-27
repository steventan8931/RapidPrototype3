using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchFX : MonoBehaviour
{
    public float m_Timer;
    public float m_DecayTime = 0.5f;

    private void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer > m_DecayTime)
        {
            Destroy(gameObject);
        }
    }
}
