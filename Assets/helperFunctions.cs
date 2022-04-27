using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class helperFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if(keyboard == null) return;

        if(keyboard.escapeKey.wasPressedThisFrame)Application.Quit();
        if(keyboard.digit9Key.wasPressedThisFrame)Application.LoadLevel(0);
    }
}
