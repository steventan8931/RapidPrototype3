using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Vector2 MoveDirection;

    public bool m_KeyCollected = false;

    void Update()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        MoveDirection = new Vector2(MoveX, MoveY);

        transform.position += new Vector3(MoveDirection.x, MoveDirection.y,0) * Time.deltaTime * 7;
    }
}
