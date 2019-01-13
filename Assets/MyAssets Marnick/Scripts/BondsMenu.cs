﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BondsMenu : MonoBehaviour {
    [SerializeField]
    private GameObject number;
    [SerializeField]
    private GameObject up;
    [SerializeField]
    private GameObject down;
	// Use this for initialization
	void Start () {
        number.GetComponent<Text>().text = UserStats.Bonds.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickUp()
    {
        if (UserStats.Bonds < 4)
        {
            ++UserStats.Bonds;
            number.GetComponent<Text>().text = UserStats.Bonds.ToString();
        }
        if (UserStats.Bonds == 4)
        {
            up.SetActive(false);
        }
        down.SetActive(true);
    }

    public void ClickDown()
    {
        if (UserStats.Bonds > 0)
        {
            --UserStats.Bonds;
            number.GetComponent<Text>().text = UserStats.Bonds.ToString();
        }
        if (UserStats.Bonds == 0)
        {
            down.SetActive(false);
        }
        up.SetActive(true);
    }
}
