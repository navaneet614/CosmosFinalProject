using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = togglePause();

        }
    }

    void OnGUI()
    {
        if (paused) 
        {
            float sWidth = Screen.currentResolution.width;
            float sHeight = Screen.currentResolution.height;
            if (GUI.Button(new Rect(0, 0, sWidth, sHeight), ""))
                paused = togglePause();
            GUIStyle style = new GUIStyle();
            style.fontSize = 200;
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.UpperCenter;
            GUI.Label(new Rect(sWidth/2-50, sHeight/2-100, 100, 50), "Game Paused!", style);
            style.fontSize = 50;
            style.alignment = TextAnchor.LowerCenter;
            GUI.Label(new Rect(sWidth / 2 - 50, sHeight / 2 + 100, 100, 50), "Click Anywhere to play. Hit escape to quit.", style);
 
        }
        if (Input.GetKey(KeyCode.Escape) && paused)
        {
            Application.Quit();
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