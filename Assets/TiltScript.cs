using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltScript : MonoBehaviour {

    public float max = 30;
    private float count;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0f)
        {
            return;
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            if (count < max)
            {
                transform.Rotate(0, 0, -1);
                count++;
            }
        }
        else
        {
            if (count != 0)
            {
                transform.Rotate(0, 0, 1);
                count--;
            }

        }

    }
}
