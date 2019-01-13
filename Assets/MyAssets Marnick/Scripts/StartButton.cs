using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {
    [SerializeField]
    private GameObject startSceneManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartClick()
    {
        if (!UserStats.Cif.Equals(""))
        {
            startSceneManager.GetComponent<StartSceneManager>().enabled = true;
        }
    }
}
