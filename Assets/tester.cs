using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float diffx;
    private float diffy;
    private float diffz;

    private void Start()
    {
        //yeet
    }

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.RotateAround(transform.parent.position, Vector3.up, yaw * Time.deltaTime);
        transform.RotateAround(transform.parent.position, Vector3.right, pitch * Time.deltaTime);
        transform.LookAt(transform.parent.position);
        

        if (Input.GetAxis("Mouse X") == 0)
        {
            yaw = 0;
        }
        if (Input.GetAxis("Mouse Y") == 0)
        {
            pitch = 0;
        }
        if (Input.GetKey("r"))
        {
            transform.position = GameObject.Find("ReturnPos").GetComponent<Transform>().position;
        }
    }
}
