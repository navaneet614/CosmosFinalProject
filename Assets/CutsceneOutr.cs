using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneOutr : MonoBehaviour {
    
    public float pspeed = 2f;
    public float rspeed = 4f;
    public float cspeed = .5f;
    public float time1 = 0;
    public float time2 = 0;

    private GameObject rocket;
    private GameObject cam;
    private GameObject[] fireworks;
    private bool flying = false;
    private bool side = false;
    private bool shaken = false;
    private bool rocketDead = false;
    private bool playerDead = false;


	void Start()
    {
        StartCoroutine("Wait");
        rocket = GameObject.Find("Rocket");
        cam = GameObject.Find("Camera");
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
        if((time2 - time1) >= 2){
            transform.Translate(Vector3.forward * pspeed * Time.deltaTime);
            if (flying)
            {
                rocket.transform.Translate(0f, rspeed, 0f);
                cam.transform.Translate(0f, rspeed, -cspeed);
                rspeed = rspeed * 1.03f;
            }

            if (rocket.transform.position.y >= 1000)
            {
                rspeed = 0f;
                cspeed = 0f;
                if (!rocketDead)
                {
                    Destroy(GameObject.Find("Rocket"));
                    rocketDead = true;
                    flying = false;
                }
                for (int index = 0; index < fireworks.Length; index++)
                {
                    fireworks[index].SetActive(true);
                }
            }

            if (shaken)
            {
                if (side)
                {
                    rocket.transform.Translate(0.1f, 0, 0);
                    side = false;
                }
                else
                {
                    rocket.transform.Translate(-0.1f, 0, 0);
                    side = true;
                }
            }
        }

	}

    IEnumerator Fly(){
        shaken = true;
        yield return new WaitForSeconds(2);
        shaken = false;
        flying = true;
        if (!playerDead){
            Destroy(GameObject.Find("Effect_03"));
            Destroy(GameObject.Find("pCube11"));
        }
    }

    IEnumerator Wait(){
        time1 = Time.time;
        yield return new WaitForSeconds(2);
        time2 = Time.time;
    }

	private void OnTriggerEnter(Collider other)
	{
        
        if(other.name == "Rocket"){
            pspeed = 0f;
            StartCoroutine("Fly");
        } 

	}

}
