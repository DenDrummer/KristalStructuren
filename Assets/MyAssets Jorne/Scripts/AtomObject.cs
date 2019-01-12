using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomObject : MonoBehaviour {
    [SerializeField]
    private Element element;
	// Use this for initialization
	void Start () {
        // GetComponent<Renderer>().material.color = Color.blue;
        element = AllElements.getElement(transform.name);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(element.abbreviation);
            print(element.atomicRadius);
        }
    }
}
