using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public Animator m_Animation;
    public GameState m_State;

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            m_Animation.ResetTrigger("Fade To");
            m_Animation.SetTrigger("Fade To");
            m_State.m_GameWin = true;
        }
    }


}
