using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    public bool[] toDisplay;
    private string[] names;


    private void Start()
    {
        toDisplay = new bool[5];
        names = new string[5];
        names[0] = "Matchbox";
        names[1] = "Wood";
        names[2] = "Sap";
        names[3] = "Fishing Line";
        names[4] = "Gunpowder";
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            paused = togglePause();
           
        }
    }

    void OnGUI()
    {
        if (paused)
        {
            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Click me to unpause"))
                paused = togglePause();
            GUILayout.Label("Inventory");
            for (int index = 0; index < toDisplay.Length; index++)
            {
                if (toDisplay[index])
                {
                    //display information on destroyed object
                    GUILayout.Label(names[index]);
                }
            }
        }
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}