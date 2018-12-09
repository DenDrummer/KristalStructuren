using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    [SerializeField]
    private GameObject aboutcanvas;
    [SerializeField]
    private GameObject instructionscanvas;

    private Text content;
    private Text startbutton;


    // Use this for initialization
    void Start()
    {
        //aboutcanvas = GameObject.FindGameObjectWithTag("initabout");
        //instructionscanvas = GameObject.FindGameObjectWithTag("initinstr");
        instructionscanvas.SetActive(false);
        aboutcanvas.SetActive(false);
        content = GameObject.FindGameObjectWithTag("maincontent").GetComponent<Text>();
        startbutton = GameObject.FindGameObjectWithTag("startbutton").GetComponent<Text>();
        SetEndScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetEndScene()
    {
        if (PlayerStats.EndGame == 1)
        {
            string endtext = String.Format("Congratulations\nYou have found all Items\n\nYour Time is {0}\n\nReady to try again?", PlayerStats.ScoreTime);
            content.text = endtext;
            startbutton.text = "Restart";
            PlayerStats.EndGame = 0;
        }
        /*
        if (PlayerPrefs.GetInt("end") == 1)
        {
            string endtext = String.Format("Congratulations\nYou have found all Items\n\nYour Time is {0}\n\nReady to try again?",PlayerPrefs.GetString("score"));
            content.text = endtext;
            startbutton.text = "restart";
            PlayerPrefs.SetInt("end",0);
            PlayerPrefs.Save();
        }
        */
    }
}
