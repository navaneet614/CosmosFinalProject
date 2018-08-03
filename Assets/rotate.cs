using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    private Transform lightTransform;
    private ItemDisplay script;

	// Use this for initialization
	void Start () {
        lightTransform = GameObject.Find("Directional Light").transform;
        script = GameObject.Find("fireBro2").GetComponent<ItemDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
        if (script.counter == 1)
        {
            lightTransform.Rotate(Vector3.right * Time.deltaTime * 45);
        }
        else if (script.counter == 2)
        {
            lightTransform.Rotate(Vector3.right * Time.deltaTime * 45);
        }
        else if (script.counter == 3)
        {
            lightTransform.Rotate(Vector3.right * Time.deltaTime * 45);
        }
        else if (script.counter == 4)
        {
            lightTransform.Rotate(Vector3.right * Time.deltaTime * 45);
        }






        //GetComponent<Rigidbody>().rotation = new Quaternion(script.counter * 45, lightTransform.rotation.y, lightTransform.rotation.z, lightTransform.rotation.w);
        Debug.Log(script.counter * 45);
	}
}
