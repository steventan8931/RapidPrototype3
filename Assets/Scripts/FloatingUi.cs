using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingUi : MonoBehaviour
{
    [SerializeField] public Transform lookAt;
    [SerializeField] public Vector3 offset;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Pos = cam.WorldToScreenPoint(lookAt.position + offset);

        if(transform.position != Pos)
        {
            transform.position = Pos;
        }
    }
}
