using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBroUserControl1 : MonoBehaviour
{

    public float speed = 5f;
    public float rotSpeed = 5f;



   
    void Update()
    {
        var x = rotSpeed * Input.GetAxis("Horizontal") * Time.deltaTime ;
        var z = speed * Input.GetAxis("Vertical") * Time.deltaTime;


      




        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }



    

}
