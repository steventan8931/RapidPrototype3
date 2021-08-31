using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SortingLayerSetter : MonoBehaviour
{
    public Renderer m_Renderer;
    public bool m_Leg;

    private void Update()
    {
        m_Renderer.sortingLayerName = "Player";

    }
}
