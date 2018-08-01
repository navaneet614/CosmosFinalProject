using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{

    private string[] names;
    private int counter;
    private int timeCounter;

    // Use this for initialization
    void Start()
    {
        names = new string[5];
        for (int index = 0; index < 5; index++)
        {
            names[index] = "NOT FOUND YET";
        }
        counter = 0;
        timeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        if (timeCounter > 0)
        {
            GUILayout.Label("Inventory:");
            for (int index = 0; index < 5; index++)
            {
                GUILayout.Label("Item " + (index + 1) + ": " + names[index]);
            }
            timeCounter--;
        }
    }

    public void AddItem(string name)
    {
        names[counter++] = name;
        timeCounter = 200;
    }
}
