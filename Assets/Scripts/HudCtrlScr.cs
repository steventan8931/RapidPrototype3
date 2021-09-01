using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudCtrlScr : MonoBehaviour
{
    public GameObject Gheart1, Gheart2, Gheart3; // hp = 3
    public GameObject Bheart1, Bheart2, Bheart3;
    public Image DrugBar;
    public GameObject GHUD, BHUD;
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
            if(player.GetComponent<playercontroller>().currentDrug>0)
            {
                Gheart1.SetActive(true);
                Gheart2.SetActive(true);
                Gheart3.SetActive(true);
            }
            else
            {
                Bheart1.SetActive(true);
                Bheart2.SetActive(true);
                Bheart3.SetActive(true);
            }
            
        }
        else if (tempHP == 2)
        {
            if (player.GetComponent<playercontroller>().currentDrug > 0)
            {
                Gheart1.SetActive(true);
                Gheart2.SetActive(true);
                Gheart3.SetActive(false);
            }
            else
            {
                Bheart1.SetActive(true);
                Bheart2.SetActive(true);
                Bheart3.SetActive(false);
            }
        }
        else if (tempHP == 1)
        {
            if (player.GetComponent<playercontroller>().currentDrug > 0)
            {
                Gheart1.SetActive(true);
                Gheart2.SetActive(false);
                Gheart3.SetActive(false);
            }
            else
            {
                Bheart1.SetActive(true);
                Bheart2.SetActive(false);
                Bheart3.SetActive(false);
            }
        }
        else if (tempHP == 0)
        {
            if (player.GetComponent<playercontroller>().currentDrug > 0)
            {
                Gheart1.SetActive(false);
                Gheart2.SetActive(false);
                Gheart3.SetActive(false);
            }
            else
            {
                Bheart1.SetActive(false);
                Bheart2.SetActive(false);
                Bheart3.SetActive(false);
            }
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
        if (player.GetComponent<playercontroller>().currentDrug > 0)
        {
            GHUD.SetActive(true);
            BHUD.SetActive(false);
        }else
        {
            GHUD.SetActive(false);
            BHUD.SetActive(true);
        }
    }
}
