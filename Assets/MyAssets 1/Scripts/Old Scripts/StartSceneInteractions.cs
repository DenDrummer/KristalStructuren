using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneInteractions : MonoBehaviour
{
    [SerializeField]
    private GameObject aboutcanvas;
    [SerializeField]
    private GameObject instructionscanvas;

    

    // Use this for initialization
    void Start () {
		//aboutcanvas = GameObject.FindGameObjectWithTag("about");
        //instructionscanvas = GameObject.FindGameObjectWithTag("instructions");
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void HandleButtonPress(string buttonText)
    {
        switch (buttonText)
        {
            case "Instructions":
                OpenInstructions();
                break;
            case "About":
                OpenAbout();
                break;
            case "Close Instructions":
                CloseInstructions();
                break;
            case "Close About":
                CloseAbout();
                break;
            case "Start Game":
                OpenMainVrGame();
                break;
            case "Restart":
                OpenMainVrGame();
                break;
        }
    }

    public void GazeAtAwaitInput()
    {
        
    }

    public void CloseAbout()
    {
        aboutcanvas.SetActive(false);
    }
    public void CloseInstructions()
    {
        instructionscanvas.SetActive(false);
    }
    public void OpenAbout()
    {
        aboutcanvas.SetActive(true);
    }

    public void OpenInstructions()
    {
        instructionscanvas.SetActive(true);
    }

    public void OpenMainVrGame()
    {
        SceneManager.LoadScene("MainVrGameProject");
    }
}
