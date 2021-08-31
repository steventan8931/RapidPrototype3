using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmManageScr : MonoBehaviour
{
    public AudioSource BgmPlayer;
    public AudioClip GoodBgm, BadBgm;
    // Start is called before the first frame update
    public void playBgm(int index)
    {
        if(index == 0)
        {
            BgmPlayer.Stop();
            BgmPlayer.clip = GoodBgm;
            
            BgmPlayer.Play();
        }
        if(index == 1)
        {
            BgmPlayer.Stop();
            BgmPlayer.clip = BadBgm;
            
            BgmPlayer.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
