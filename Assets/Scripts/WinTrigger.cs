using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public Animator m_Animation;
    public bool m_Triggered;
    public float m_Timer;
    private playercontroller m_Player;

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            m_Animation.ResetTrigger("Fade To");
            m_Animation.SetTrigger("Fade To");
            m_Animation.SetBool("Fade Back", false);
            m_Triggered = true;
            m_Player = _collision.GetComponent<playercontroller>();
        }
    }

    private void Update()
    {
        if (m_Triggered)
        {
            m_Timer += Time.deltaTime;
        } 
        if (m_Timer > 1)
        {
            m_Player.WinFunc();
        }
    }

}
