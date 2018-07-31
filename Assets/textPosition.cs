using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.currentResolution.width/1920f*0, Screen.currentResolution.height/1080f*-375);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
