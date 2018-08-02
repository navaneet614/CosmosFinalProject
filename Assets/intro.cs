using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("ToggleStuff");
	}
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator ToggleStuff()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Rigidbody>().useGravity = true;
        GameObject.Find("Effect_07").SetActive(false);
        transform.Find("pCube11").gameObject.SetActive(true);
        StartCoroutine("EnableStuff");
    }


    IEnumerator EnableStuff()
    {
        yield return new WaitForSeconds(8);
        GameObject.Find("pCube11").GetComponent<TiltScript>().enabled = true;
        gameObject.GetComponent<fireBroUserControl1>().enabled = true;
    }

}
