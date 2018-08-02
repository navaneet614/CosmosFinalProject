using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //GameObject.Find("Camera").GetComponent<CinemachineBrain>().enabled = false;

        StartCoroutine("FireWorksToggle1");
	}
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator FireWorksToggle1()
    {
        yield return new WaitForSeconds(2);
        GameObject.Find("Effect_07").SetActive(false);
        StartCoroutine("FireWorksToggle2");

    }


    IEnumerator FireWorksToggle2()
    {
        yield return new WaitForSeconds(2);
        GameObject.Find("Effect_07 (1)").SetActive(false);
        StartCoroutine("FireWorksToggle3");

    }


    IEnumerator FireWorksToggle3()
    {
        yield return new WaitForSeconds(2);
        GameObject.Find("Effect_07 (2)").SetActive(false);
        StartCoroutine("ToggleStuff");
    }

    IEnumerator ToggleStuff()
    {
        yield return null;
        GetComponent<Rigidbody>().useGravity = true;
        //transform.Find("pCube11").gameObject.SetActive(true);
        //GameObject.Find("pCube11").SetActive(true);
        GameObject.Find("pCube11").GetComponent<MeshRenderer>().enabled = true;
        //GameObject.Find("Effect_04").SetActive(true);
        //GameObject.Find("Effect_04 (1)").SetActive(true);
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down*10, ForceMode.Impulse);
        StartCoroutine("EnableStuff");
    }


    IEnumerator EnableStuff()
    {
        yield return new WaitForSeconds(6);
        GameObject.Find("pCube11").GetComponent<TiltScript>().enabled = true;
        gameObject.GetComponent<fireBroUserControl1>().enabled = true;
        //GameObject.Find("Camera").GetComponent<CinemachineBrain>().enabled = true;
    }

}
