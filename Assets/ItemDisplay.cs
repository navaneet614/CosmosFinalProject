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
        names = new string[4];
        for (int index = 0; index < 4; index++)
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
            for (int index = 0; index < counter; index++)
            {
                GUILayout.Label(names[index]);
            }
            timeCounter--;
        }
        if (counter > 3)
        {
            GUILayout.Label("You've collected all the items! Now you can build a rocket!");
        }
    }

    public void AddItem(string name)
    {
        names[counter++] = name;
        timeCounter = 200;
    }
}
