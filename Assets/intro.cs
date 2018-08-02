using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Camera").GetComponent<CinemachineBrain>().enabled = false;
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
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down*300, ForceMode.Impulse);
        StartCoroutine("EnableStuff");
    }


    IEnumerator EnableStuff()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("pCube11").GetComponent<TiltScript>().enabled = true;
        gameObject.GetComponent<fireBroUserControl1>().enabled = true;
        
        if (GameObject.Find("fireBro2").transform.position.y <= 250)
        {
            GameObject.Find("Camera").GetComponent<CinemachineBrain>().enabled = true;
        }
    }

}
