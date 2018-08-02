using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneOutr : MonoBehaviour {
    
    public float pspeed = 5f;
    public float rspeed = 4f;
    public float cspeed = .5f;

    private GameObject rocket;
    private GameObject cam;
    private GameObject[] fireworks;
    private bool destroyed;
	

	void Start()
    {
        rocket = GameObject.Find("Rocket");
        cam = GameObject.Find("Camera");
        destroyed = false;
        fireworks = new GameObject[14];
        fireworks[0] = GameObject.Find("Effect_07");
        fireworks[1] = GameObject.Find("Effect_07 (1)");
        fireworks[2] = GameObject.Find("Effect_07 (2)");
        fireworks[3] = GameObject.Find("Effect_07 (3)");
        fireworks[4] = GameObject.Find("Effect_07 (4)");
        fireworks[5] = GameObject.Find("Effect_07 (5)");
        fireworks[6] = GameObject.Find("Effect_07 (6)");
        fireworks[7] = GameObject.Find("Effect_07 (7)");
        fireworks[8] = GameObject.Find("Effect_07 (8)");
        fireworks[9] = GameObject.Find("Effect_07 (9)");
        fireworks[10] = GameObject.Find("Effect_07 (10)");
        fireworks[11] = GameObject.Find("Effect_07 (11)");
        fireworks[12] = GameObject.Find("Effect_07 (12)");
        fireworks[13] = GameObject.Find("Effect_07 (13)");
        for (int index = 0; index < fireworks.Length; index++) {
            fireworks[index].SetActive(false);
        }
    }

	private void Update()
	{
        transform.Translate(Vector3.forward * pspeed * Time.deltaTime);
        if (flying){
            rocket.transform.Translate(0, rspeed, 0);
            cam.transform.Translate(0, rspeed, -cspeed);
        }

        if(rocket.transform.position.y >= 1000){
            rspeed = 0f;
            cspeed = 0f;
            destroyed = true;
            Destroy(GameObject.Find("Rocket"));
            for (int index = 0; index < fireworks.Length; index++) {
                fireworks[index].SetActive(true);
            }
        }
        if (destroyed) {
            // transition to poem
        }
        
	}

    IEnumerator Fly(){
        yield return new WaitForSeconds(2);
        flying = true;
        Destroy(GameObject.Find("Effect_03"));
        Destroy(GameObject.Find("pCube11"));
    }

	private bool flying = false;

	private void OnTriggerEnter(Collider other)
	{
        
        if(other.name == "Rocket"){
            pspeed = 0f;
            StartCoroutine("Fly");
        } 
        //if (other.name=="stopFly"){
        //    rspeed = 0f;
        //    cspeed = 0f;



        //}

	}

}
