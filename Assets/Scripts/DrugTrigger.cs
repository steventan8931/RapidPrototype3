﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.gameObject.layer == 9)
        {
            Debug.Log("eat drig");
        }
    }

    public void eatDrug()
    {
        Destroy(gameObject);
    }
}
