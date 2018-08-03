using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    private Transform lightTransform;
    private ItemDisplay script;
    public Material first;
    public Material second;
    public Material third;
    public Material fourth;
    public Material fifth;
    private Material[] skyboxes;


    private float angle = -1;

	// Use this for initialization
	void Start () {
        lightTransform = GameObject.Find("Directional Light").transform;
        script = GameObject.Find("fireBro2").GetComponent<ItemDisplay>();
        skyboxes = new Material[5];
        skyboxes[0] = first;
        skyboxes[1] = second;
        skyboxes[2] = third;
        skyboxes[3] = fourth;
        skyboxes[4] = fifth;
    }
	
	// Update is called once per frame
	void Update () {

        if (angle != script.counter*45)
        {
           // angle = script.counter*45;
           // lightTransform.localEulerAngles = new Vector3(angle,
           //lightTransform.localEulerAngles.y, lightTransform.localEulerAngles.z);
            RenderSettings.skybox = skyboxes[script.counter];
        }

        


        

        //GetComponent<Rigidbody>().rotation = new Quaternion(script.counter * 45, lightTransform.rotation.y, lightTransform.rotation.z, lightTransform.rotation.w);
        //Debug.Log(script.counter * 45);
	}
}
