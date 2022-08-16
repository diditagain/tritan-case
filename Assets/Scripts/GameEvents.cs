using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{

    public static GameEvents instance;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
    public event Action speedUpCharacter, slowDownCharacter;
    public void SpeedUpCharacter()
    {
        if (speedUpCharacter != null) { speedUpCharacter(); }
    }

    public void SlowDownCharacter()
    {
        if (slowDownCharacter != null) { slowDownCharacter(); }
        Debug.Log("Hello from game events");
    }
}
