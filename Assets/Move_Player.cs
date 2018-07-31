using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Move_Player : MonoBehaviour {
    public float MoveSpeed = 5f;
    public float TurnSpeed = 3f;
    void Update () {
        
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.up, -TurnSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up, TurnSpeed * Time.deltaTime);
        }
        

    }

    private void OnCollisionEnter(Collision coll)
    {
        Debug.Log("collided with " + coll.gameObject.name);
    }

}
