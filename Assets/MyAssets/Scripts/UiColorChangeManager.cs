using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiColorChangeManager : MonoBehaviour {
    //Change color of ui to color of atom
	// Use this for initialization
    private Material materialParent;
    private Image materialsChildren;

	void Start () {
        
        //Fetch the Renderer from the GameObject
	    materialParent = transform.parent.GetComponent<Renderer>().material;
	    materialsChildren = GetComponentInChildren<Image>();

	    //foreach (Image mat in materialsChildren)
	    //{
	        materialsChildren.color = materialParent.color;
	    //}
        /*
	    //Set the main Color of the Material to green
            rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);

        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);
        */
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
