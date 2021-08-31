using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if(_collision.tag == "Player")
        {
            //Replace with actual player's keycollected bool
            _collision.GetComponent<playercontroller>().hasKey = true;


            Destroy(gameObject);
        }
    }
}
