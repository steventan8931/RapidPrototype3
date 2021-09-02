using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEndMovingPole : MonoBehaviour
{
    public Vector3 m_StartPos;
    public Vector3 m_EndPos;

    private void Update()
    {
        if (transform.position != m_EndPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_EndPos, Time.deltaTime * 1.5f);

        }
        else
        {
            transform.position = m_StartPos;
        }

    }
}
