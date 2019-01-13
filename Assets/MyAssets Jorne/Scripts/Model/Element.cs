using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element{
    public int atomicNumber { get; set; }
    public string name { get; set; }
    public string abbreviation { get; set; }
    public float mass { get; set; }
    public float atomicRadius { get; set; }
    public Color color {get; set; }

    public Element(string atomicNumber,string abbreviation,string name,string mass,string color,string waalsRadius,string atomicRadius) {
        this.atomicNumber = Int32.Parse(atomicNumber);
        this.abbreviation = abbreviation;
        this.name = name;
        this.color =new Color(int.Parse(color.Substring(0,2), System.Globalization.NumberStyles.AllowHexSpecifier), int.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier), int.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
        if (atomicRadius.Equals("")) {
            this.atomicRadius = 100;
        }else this.atomicRadius = float.Parse(atomicRadius);
    }


}
