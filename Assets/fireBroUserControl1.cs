using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBroUserControl1 : MonoBehaviour
{

    public float speed = 5f;
    public float rotSpeed = 5f;
    private bool rotated = false;

   
    void Update()
    {
        var x = rotSpeed * Input.GetAxis("Horizontal") * Time.deltaTime ;
        var z = speed * Input.GetAxis("Vertical") * Time.deltaTime;


        //if (!rotated && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        //{
        //    transform.Rotate(45, 0, 0);
        //    rotated = true;
        //}
        //else
        //{
        //    if (rotated)
        //    {
        //        transform.Rotate(-45, 0, 0);
        //        rotated = false;
        //    }
        //}




        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }



    

}
