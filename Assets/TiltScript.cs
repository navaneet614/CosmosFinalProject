using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltScript : MonoBehaviour {

    public float max = 30;
    private float fcount, bcount;

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
            if (fcount < max)
            {
                transform.Rotate(0, 0, -1);
                if (bcount > 0)
                {
                    bcount--;
                }
                else
                {
                    fcount++;
                }
            }
        }
        //code for tilt backwards
        //else if((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        //{
        //    if (bcount < max)
        //    {
        //        transform.Rotate(0, 0, 1);
        //        if (fcount > 0)
        //        {
        //            fcount--;
        //        }else
        //        {
        //            bcount++;
        //        }
        //    }
        //}
        else
        {
            if (fcount != 0)
            {
                transform.Rotate(0, 0, 1);
                fcount--;
            }
            else if (bcount != 0)
            {
                transform.Rotate(0, 0, -1);
                bcount--;
            }
        }

    }
}
