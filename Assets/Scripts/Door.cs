using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool m_IsOpen;
    public bool m_StaysOpen = true;

    public GameObject m_OpenDoor;
    public GameObject m_ClosedDoor;

    private void Update()
    {
        if (m_IsOpen)
        {
            m_OpenDoor.SetActive(true);
            m_ClosedDoor.SetActive(false);
        }
        else
        {
            m_OpenDoor.SetActive(false);
            m_ClosedDoor.SetActive(true);
        }
    }
}
