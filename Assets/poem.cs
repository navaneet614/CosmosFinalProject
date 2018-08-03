using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class poem : MonoBehaviour
{

    public Text words;

    public Texture title, inspired;

    private GameObject cam; 

    // Use this for initialization
    void Start()
    {
        cam = GameObject.Find("Camera");
        words.text = "";
        //GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.currentResolution.width / 1920 * 400, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.position.y >= 941)
        {
            StartCoroutine("Thing");
        }
    }

    IEnumerator Thing()
    {
        yield return new WaitForSeconds(4);
    //    words.text = "Happiness comes in small \n bursts of \n fireworks and I, \n" +
    //"I fizzle out. \n \n The embers " + "are reminders \n of past innocence and \n naivety \n \n" +
    //"so gullible, so sweet \n so… \n \n t r u s t i n g. \n \n" +
    //"Shattered, falling, \n I am brought \n back to \n those days \n once more \n \n" +
    //"as a new spark, \n a spark within me \n burns \n brighter \n \n" +
    //"s t r o n g e r, \n \n leaving me \n full of wonder \n eager to explore \n \n" +
    //"to find a new day, \n to forge a new me.";
        dos = true;
    }

    bool dos = false;
    public void OnGUI()
    {
        if (dos){
            float sWidth = Screen.currentResolution.width;
            float sHeight = Screen.currentResolution.height;
            if (GUI.Button(new Rect(0, 0, sWidth, sHeight), ""))
                SceneManager.LoadScene("Menu_Scene");
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.UpperCenter;
            GUI.DrawTexture(new Rect(sWidth / 2 - 400, 10, 400, 210), inspired, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(sWidth / 2, 10, 400, 210), title, ScaleMode.StretchToFill);
            GUI.Label(new Rect(sWidth / 2 - 200, 230, 50, sHeight), "Happiness comes in small\nbursts of\nfireworks and I,\nI fizzle out.\n\nThe embers\nleft behind\n\nf o r g o t t e n,\n\nare reminders\nof past innocence and\nnaivety\n\nso gullible, so sweet\nso…\n\nt r u s t i n g.", style);
            GUI.Label(new Rect(sWidth / 2 + 200, 230, 50, sHeight), "Shattered, falling,\nI am brought\nback to\nthose days\nonce more\n\nas a new spark,\na spark within me\nburns\nbrighter\n\ns t r o n g e r,\n\nleaving me\nfull of wonder\neager to explore\n\nto find a new day,\nto forge a new me.", style);
            style.fontSize = 20;
            GUI.Label(new Rect(sWidth / 2 - 200, sHeight * 7 / 8, + 400, sHeight), "Click anywhere to return to the main menu", style);
        }
    }
}
