using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudCtrlScr : MonoBehaviour
{
    public GameObject heart1, heart2, heart3; // hp = 3
    public Image DrugBar;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void checkHeart()
    {
        int tempHP;
        tempHP = player.GetComponent<playercontroller>().hitpoints;
        if(tempHP == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (tempHP == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if (tempHP == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else if (tempHP == 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
    }

    void checkDrug()
    {
        float tempDrug;
        tempDrug = player.GetComponent<playercontroller>().currentDrug;
        
        float drugScale = tempDrug * 0.01f;
        //print(drugScale);
        DrugBar.fillAmount = drugScale;
    }

    // Update is called once per frame
    void Update()
    {
        checkHeart();
        checkDrug();
    }
}
