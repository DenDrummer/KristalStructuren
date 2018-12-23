
using System;
using UnityEngine;

public class Element{
    private int AtomicNumber { get; set; }
    private string Name { get; set; }
    //Key of the element
    public string Abbreviation { get; set; }
    private float Mass { get; set; }
    private float WaalsRadius { get; set; }
    public Color Color {get; set; }

    public Element(string atomicNumber,string abbreviation,string name,string mass,string color,string waalsRadius) {
        this.AtomicNumber = Int32.Parse(atomicNumber);
        this.Abbreviation = abbreviation.Replace(" ",string.Empty);
        this.Name = name;
        //this.mass = float.Parse(mass);
        //this.waalsRadius = float.Parse(waalsRadius);
        this.Color =new Color(int.Parse(color.Substring(0,2), System.Globalization.NumberStyles.AllowHexSpecifier), int.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier), int.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
    
    }


}
