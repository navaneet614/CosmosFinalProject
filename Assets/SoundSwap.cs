using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSwap : MonoBehaviour {
    public Component[] sounds;
    // Use this for initialization
    void Start() {
        sounds = GetComponents(typeof(AudioSource));
        Debug.Log(sounds[0],sounds[1]);
    }

        // Update is called once per frame
        void Update() {

        }
    }

