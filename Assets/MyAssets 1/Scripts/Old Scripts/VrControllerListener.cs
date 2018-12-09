﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrControllerListener : MonoBehaviour {
    KeyCode BluetoothReturn = (KeyCode)10;

    // Update is called once per frame
    void Update () {
        //For VR controller
        if (Input.GetKeyDown(BluetoothReturn))
        {
            gameObject.GetComponent<StartSceneInteractions>().HandleButtonPress(gameObject.GetComponentInChildren<Text>().text);
        }
    }
}
