using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grab : MonoBehaviour
{

    private GameObject man;
    public Text pickF;
    private bool destroyed;
    private bool isClose;
    private ItemDisplay script;
    public string objName;

    // Use this for initialization
    void Start()
    {
        man = GameObject.Find("fireBro2");
        pickF.text = "";
        destroyed = false;
        isClose = true;
        script = GameObject.Find("fireBro2").GetComponent<ItemDisplay>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = man.transform.position;
        if (!destroyed && Vector3.Distance(pos, transform.position) <= 5)
        {
            isClose = true;
            pickF.text = "Press 'F' to pick up the object.";
            //the message to press f
            if (Input.GetKey(KeyCode.F))
            {
                pickF.text = "";
                destroyed = true;
                script.AddItem(objName);
                Destroy(gameObject, 0);
            }
        }
        else
        {
            isClose = false;
        }

        if (!destroyed && !isClose)
        {
            pickF.text = "";
        }
    }
}
