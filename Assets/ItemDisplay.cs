using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{

    private string[] names;
    private int counter;
    private int timeCounter;
    public Texture inventory;
    public Texture wood;
    public Texture treeSap;
    public Texture fishingLine;
    public Texture matchBox;
    public float imageSize = 50;
    public float offset = 10;



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
            float sWidth = Screen.currentResolution.width;
            float sHeight = Screen.currentResolution.height;
            imageSize = sWidth / 1920 * imageSize;
            GUIStyle style = new GUIStyle();
            GUI.DrawTexture(new Rect(0, 0, imageSize * 2, imageSize), inventory, ScaleMode.StretchToFill);
            //GUI.Label(new Rect(), "Inventory:", style);
            for (int index = 0; index < counter; index++)
            {
                //GUILayout.Label(names[index]);
                Texture t = null;
                switch (names[index]) {
                    case "Tree Sap":
                        t = treeSap;
                        break;
                    case "Wood":
                        t = wood;
                        break;
                    case "Fishing Line":
                        t = fishingLine;
                        break;
                    case "Matchbox":
                        t = matchBox;
                        break;
                }

                GUI.DrawTexture(new Rect(index*imageSize + offset*(index+1) + imageSize*2,0,imageSize,imageSize), t, ScaleMode.StretchToFill);
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
        timeCounter = 500;
    }
}
