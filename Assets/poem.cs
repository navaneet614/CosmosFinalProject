using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class poem : MonoBehaviour
{

    public Text words;

    private GameObject cam; 

    // Use this for initialization
    void Start()
    {
        cam = GameObject.Find("Camera");
        words.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.position.y >= 941)
        {
            words.text = "Happiness comes in small \n bursts of \n fireworks and I, \n" +
                "I fizzle out. \n \n The embers " + "are reminders \n of past innocence and \n naivety \n \n" +
                "so gullible, so sweet \n so… \n \n t r u s t i n g. \n \n" +
                "Shattered, falling, \n I am brought \n back to \n those days \n once more \n \n" +
                "as a new spark, \n a spark within me \n burns \n brighter \n \n" +
                "s t r o n g e r, \n \n leaving me \n full of wonder \n eager to explore \n \n" +
                "to find a new day, \n to forge a new me.";
        }
    }
}
