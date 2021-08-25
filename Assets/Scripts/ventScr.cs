using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventScr : MonoBehaviour
{
    public Transform exitLocation;
    private GameObject player;
    public Transform getExit()
    {
        Transform templocation = exitLocation;
        return templocation;
    }

    public void checkPlayer()
    {
        Transform tempLoc = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 ventLoc = new Vector2(transform.position.x, transform.position.y);
        Vector2 PlayerLoc = new Vector2(tempLoc.position.x, tempLoc.position.y);
        if (Vector2.Distance(ventLoc,PlayerLoc) <= 0.3)
        {
            print("Player Detected!");
            player.GetComponent<playercontroller>().nearVent = true;
            player.GetComponent<playercontroller>().getNextVentLoc(exitLocation);
        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayer();
    }
}
