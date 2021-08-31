using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManageScr : MonoBehaviour
{
    public AudioClip walkSound, jumpSound, keySound, drugSound,scratchSound,doorSound,monAttackSound,ventSound;
    public AudioClip closetSound;
    static AudioSource audioSrc;
    void Start()
    {
      
        audioSrc = GetComponent<AudioSource>();
    }
    public void PlaySound (string clip)
    {
        switch(clip)
        {
            case "walk":
                audioSrc.PlayOneShot(walkSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "key":
                audioSrc.PlayOneShot(keySound);
                break;
            case "drug":
                audioSrc.PlayOneShot(drugSound);
                break;
            case "door":
                audioSrc.PlayOneShot(doorSound);
                break;
            case "scratch":
                audioSrc.PlayOneShot(scratchSound);
                break;
            case "attack":
                audioSrc.PlayOneShot(monAttackSound);
                break;
            case "vent":
                audioSrc.PlayOneShot(ventSound);
                break;
            case "closet":
                audioSrc.PlayOneShot(closetSound);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
