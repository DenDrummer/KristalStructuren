﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAtomManager : MonoBehaviour
{
    private bool activated;

    void Start()
    {
        activated = false;
    }

    public void ButtonPress()
    {
        activated = !activated;
        foreach (Transform child in transform)
        {
            foreach (Transform innerChild in child)
            {
                innerChild.gameObject.SetActive(activated);
            }
        }
    }
}
