using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    private Transform playerTransform;

    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        print(playerTransform);
    }

    //called after update and fixed update
    private void LateUpdate()
    {
        //store the current camera's position
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        // add offset to camera if needeed
        temp.x += offset;
        //set back  the camera's temp position to camera's current position
        transform.position = temp;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
