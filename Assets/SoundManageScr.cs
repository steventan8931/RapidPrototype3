using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManageScr : MonoBehaviour
{
    public AudioClip walkSound, jumpSound, keySound, drugSound;
    static AudioSource audioSrc;
    void Start()
    {
      
        audioSrc = GetComponent<AudioSource>();
    }
    public void PlaySound (string clip)
    {
        switch(clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "key":
                audioSrc.PlayOneShot(keySound);
                break;
            case "drug":
                audioSrc.PlayOneShot(drugSound);
                break;



        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
