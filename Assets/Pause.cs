using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Texture pauseScreen;
    private bool paused = false;

    private void Start()
    {
        Cursor.visible = false;
    }

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
            //GUIStyle style = new GUIStyle();
            //style.fontSize = 200;
            //style.normal.textColor = Color.white;
            //style.alignment = TextAnchor.UpperCenter;
            //GUI.Label(new Rect(sWidth/2-50, sHeight/2-100, 100, 50), "Game Paused!", style);
            //style.fontSize = 50;
            //style.alignment = TextAnchor.LowerCenter;
            //GUI.Label(new Rect(sWidth / 2 - 50, sHeight / 2 + 100, 100, 50), "Click Anywhere to play. Hit escape to quit.", style);

            
            GUI.DrawTexture(new Rect(sWidth/4, sHeight/4, sWidth/2, sHeight/2), pauseScreen, ScaleMode.StretchToFill);
 
        }
        if (Input.GetKey(KeyCode.Escape) && paused)
        {
            paused = togglePause();
            Cursor.visible = true;
            SceneManager.LoadScene("Menu_Scene");
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