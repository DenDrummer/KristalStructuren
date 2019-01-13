using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetContentBondMeasure : MonoBehaviour
{
    private Text[] bondText;

	// Use this for initialization
	void Start ()
	{
        /*
	    bondText = transform.GetComponentsInChildren<Text>();
        foreach (var text in bondText)
        {
            if (text.name.ToLower().Equals("distance"))
            {
                text.text = transform.localScale.z.ToString() + " A";
            }
        }*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
