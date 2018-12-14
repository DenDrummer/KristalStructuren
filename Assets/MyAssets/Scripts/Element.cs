using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element{
    private int atomicNumber { get; set; }
    private string name { get; set; }
    //Key of the element
    public string abbreviation { get; set; }
    private float mass { get; set; }
    private float ionRadius { get; set; }
    public Color color {get; set; }

    public Element(string atomicNumber,string abbreviation,string name,string mass,string color,string waalsRadius,string ionRadius) {
        this.atomicNumber = Int32.Parse(atomicNumber);
        this.abbreviation = abbreviation.Replace(" ",string.Empty);
        this.name = name;
        //this.mass = float.Parse(mass);
        //this.waalsRadius = float.Parse(waalsRadius);
        this.color =new Color(int.Parse(color.Substring(0,2), System.Globalization.NumberStyles.AllowHexSpecifier), int.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier), int.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
        this.ionRadius = float.Parse(ionRadius);
    }


}
