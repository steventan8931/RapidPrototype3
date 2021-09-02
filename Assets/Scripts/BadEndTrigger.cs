using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEndTrigger : MonoBehaviour
{
    public Animator m_Animation;
    public bool m_Triggered;
    public float m_Timer;
    private playercontroller m_Player;

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
                m_Triggered = true;
                m_Player = _collision.GetComponent<playercontroller>();
            
        }
    }

    private void Update()
    {
        if (m_Triggered)
        {
            m_Timer += Time.deltaTime;

            m_Animation.ResetTrigger("Fade To");
            m_Animation.SetTrigger("Fade To");
            m_Animation.SetBool("Fade Back", false);
        }
        if (m_Timer > 2)
        {
            m_Player.BadEndFunc();
        }
    }
}
