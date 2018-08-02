using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inspect : MonoBehaviour
{

    private GameObject man;
    public Text pickF;
    private bool isClose;
    private ItemDisplay script;
    public string objName;
    public int senseRadius;
    public bool itemsCollected;
    public string message;

    // Use this for initialization
    void Start()
    {
        man = GameObject.Find("fireBro2");
        pickF.text = "";
        isClose = true;
        script = GameObject.Find("fireBro2").GetComponent<ItemDisplay>();
        senseRadius = 8;
        itemsCollected = false;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = man.transform.position;
        if (Vector3.Distance(pos, transform.position) <= senseRadius)
        {
            isClose = true;
            pickF.text = "Hold 'I' to inspect.";
            //the message to press f
            if (Input.GetKey(KeyCode.I))
            {
                if (itemsCollected)
                {
                    SceneManager.LoadScene("Outro");
                }
                pickF.text = message;
            }
        }
        else
        {
            isClose = false;
        }

        if (!isClose)
        {
            pickF.text = "";
        }
    }
}
