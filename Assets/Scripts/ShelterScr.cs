using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterScr : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Floating UI appear

        // Do change ishidden
        player.GetComponent<playercontroller>().ishidden = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Do change ishidden
        player.GetComponent<playercontroller>().ishidden = false;
    }
}
