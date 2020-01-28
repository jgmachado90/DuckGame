using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DeathCounter : MonoBehaviour
{
    public static DeathCounter instance = null;
    public TextMeshProUGUI deathCounterText;
    public int deathCounter;

    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    internal void Add()
    {
        deathCounter++;
        deathCounterText.text = deathCounter.ToString();
    }
}
