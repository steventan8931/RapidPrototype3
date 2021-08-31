using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SortingLayerSetter : MonoBehaviour
{
    public Renderer m_Renderer;
    public bool m_IsPlayer = false;

    private void Update()
    {
        if (m_IsPlayer)
        {
            m_Renderer.sortingLayerName = "Player";
        }
        else
        {
            m_Renderer.sortingLayerName = "Enemy";
        }


    }
}
