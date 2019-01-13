using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtomGuiDetails : MonoBehaviour {
    Element element;
    [SerializeField]
    Text InfoContent;
    [SerializeField]
    Text Title;

    void InitializeElement(int nr) {
        Debug.Log("Test");
        element = AllElements.getElementByNumber(nr);
        
    }

    // Use this for initialization
    void Start () {
        InfoContent.text = "Hallokes";//"Element:" + element.name + "\nRadius: " + element.atomicRadius + "\nKleur: " + element.color;
        Title.text = transform.name;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
