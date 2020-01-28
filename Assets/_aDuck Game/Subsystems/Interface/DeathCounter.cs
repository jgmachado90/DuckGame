using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DeathCounter : MonoBehaviour
{
    public static DeathCounter instance;
    public TextMeshProUGUI deathCounterText;
    public int deathCounter;

    void Awake()
    {
        instance = this;
    }

    internal void Add()
    {
        deathCounter++;
        deathCounterText.text = deathCounter.ToString();
    }
}
